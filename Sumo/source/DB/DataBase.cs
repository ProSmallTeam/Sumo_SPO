using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sumo.Api;

namespace DB
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class DataBase : IDataBase
    {
        public MongoDatabase Database;

        private readonly string _nameOfDataBase;

        #region Коллекции

        // Коллекция, в которой хранится информация о книгах.
        public static MongoCollection<BsonDocument> Books;

        // Коллекция, в которой хранится всесь список аттрибутов.
        public static MongoCollection<BsonDocument> Attributes;

        // Коллекция, в которой хранятся прочие данные о книгах.
        public static MongoCollection<BsonDocument> AlternativeMeta;

        // Колекция, в которой хранятся задания на обработку книг.
        public static MongoCollection<BsonDocument> Tasks;

        #endregion
        
        public DataBase(string connectiongString, string nameOfDataBase = Resources.MongoDataBaseName)
        {
            var client = new MongoClient(connectiongString);
            var server = client.GetServer();

            _nameOfDataBase = nameOfDataBase;

            Database = server.GetDatabase(_nameOfDataBase);

            SetCollections();
        }

        private void SetCollections()
        {
            Books = Database.GetCollection<BsonDocument>("Books");

            Attributes = Database.GetCollection<BsonDocument>("Attributes");

            AlternativeMeta = Database.GetCollection<BsonDocument>("AlternativeMeta");

            Tasks = Database.GetCollection<BsonDocument>("Tasks");

        }

        public List<BsonDocument> Find(IMongoQuery query, MongoCollection collection)
        {
            return collection.FindAs<BsonDocument>(query).ToList();
        }

        public void Indexing()
        {
            Books.EnsureIndex(new IndexKeysBuilder().Ascending("Attributes"));
            Attributes.EnsureIndex(new IndexKeysBuilder().Ascending("_id"));
            Attributes.EnsureIndex(new IndexKeysBuilder().Ascending("FatherRef"));
            AlternativeMeta.EnsureIndex(new IndexKeysBuilder().Ascending("_id"));
        }

        public void Drop()
        {
            Database.Drop();
        }

        public int SaveBookMeta(Book book, List<Book> alternativeBook = null)
        {
            try
            {
                var idOfAltMeta = new List<int>();

                if (alternativeBook != null)
                    foreach (var altBookMeta in alternativeBook.Select(altBook => CreateBook(altBook, AlternativeMeta)))
                    {
                        AlternativeMeta.Insert(altBookMeta);

                        idOfAltMeta.Add(int.Parse(altBookMeta["_id"].ToString()));
                    }

                var document = CreateBook(book, Books, idOfAltMeta);

                Books.Insert(document);

                return 0;
            }
            catch (Exception)
            {

                return -1;
            }

        }

        public int DeleteBookMeta(string md5Hash)
        {
            try
            {
                var query = new QueryDocument(new BsonDocument { { "Md5Hash", md5Hash } });

                var book = Books.FindOneAs<BsonDocument>(query);

                Books.Remove(query);

                var stringOfid = book["AlternativeMeta"].ToString();
                var idOfAltMeta = stringOfid
                                           .Substring(1, stringOfid.Length - 2)
                                           .Split(new[] { ',' }).ToList();

                foreach (var id in idOfAltMeta)
                {
                    query = new QueryDocument(new BsonDocument { { "_id", int.Parse(id) } });

                    AlternativeMeta.Remove(query);

                }

                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static BsonDocument CreateBook(Book book, MongoCollection<BsonDocument> collections, IEnumerable<int> idOfAltMeta = null)
        {
            var attributes = new List<int>();

            if (book.SecondaryFields != null)
                attributes = GetListOfAttributes(book);

            var document = new BsonDocument
                {
                    {"_id", collections.Count()},
                    {"Md5Hash", book.Md5Hash},
                    {"Name", book.Name},
                    {"Path", book.Path}, //место подключения поддержки различных пользователей
                    {"Attributes", new BsonArray(attributes)},
                    {"AlternativeMeta", idOfAltMeta != null ? new BsonArray(idOfAltMeta) : null }
                };

            return document;
        }

        private static List<int> GetListOfAttributes(Book book)
        {
            var attributes = new List<int>();
            foreach (var field in book.SecondaryFields)
                foreach (var nameOfAttribute in field.Value)
                {
                    var document = new QueryDocument(new BsonDocument {{"Name", nameOfAttribute}});
                    var attribute = Attributes.FindOneAs<BsonDocument>(document);
                    if (attribute == null)
                        throw new NoAttrException();

                    var idAttr = int.Parse(attribute["_id"].ToString());

                    AddFatherAttr(attribute, attributes);

                    attributes.Add(idAttr);
                }

            return attributes;
        }

        private static void AddFatherAttr(BsonDocument attribute, List<int> attributes)
        {
            var document = new QueryDocument(new BsonDocument { { "_id", int.Parse(attribute["FatherRef"].ToString()) } });
            var fatherAttr = Attributes.FindOneAs<BsonDocument>(document);

            if (fatherAttr == null) return;

            AddFatherAttr(fatherAttr, attributes);

            var idAttr = int.Parse(fatherAttr["_id"].ToString());
            attributes.Add(idAttr);
        }

        public bool IsHaveBookMeta(string md5Hash)
        {
            return Books.Find(new QueryDocument(new BsonDocument { { "Md5Hash", md5Hash } })).Any();
        }

        public int GetStatistic(string query)
        {
            var attrId = new QueryCreator().Convert(query);

            return GetStatistic(attrId);
        }

        public List<Book> GetBooks(string query, int limit = 0, int offset = 0)
        {
            if (query == null) return ConvertToBook(Books.FindAllAs<BsonDocument>().ToList());

            var attrId = new QueryCreator().Convert(query);

            return GetBooksByAttrId(attrId, limit, offset);
        }

        public static int GetStatistic(List<int> attrId)
        {
            var queries = new QueryDocument(true);

            foreach (var id in attrId)
            {
                queries.Add("Attributes", id);
            }

            return (int)Books.FindAs<BsonDocument>(queries).Count();
        }

        private List<Book> GetBooksByAttrId(IEnumerable<int> attrId, int limit = 0, int offset = 0)
        {
            var query = new QueryDocument(true);

            foreach (var id in attrId)
            {
                query.Add("Attributes", id);
            }

            return ConvertToBook(Books.FindAs<BsonDocument>(query).SetLimit(limit).SetSkip(offset).ToList());
        }

        /// <summary>
        /// TODO: удалить метод при первой возможности.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parrentId"></param>
        /// <param name="rootId"></param>
        /// <returns></returns>
        public int SaveAttribute(string name, int parrentId, int rootId)
        {
            var IsRoot = false;

            try
            {
                Attributes.Insert(new BsonDocument
                    {
                        {"_id", Attributes.Count()},
                        {"Name", name},
                        {"IsRoot", IsRoot},
                        {"RootRef", rootId},
                        {"FatherRef", parrentId}
                    }
                    );

                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int InsertTask(Task task, bool flagOfHighPriority = false)
        {
            return new TaskManager().InsertTask(Tasks, task, flagOfHighPriority);
        }

        public int RemoveTask(Task task)
        {
            return new TaskManager().RemoveTask(Tasks, task);
        }

        public List<Task> GetTask(int quantity)
        {
            return new TaskManager().GetTask(Tasks, quantity);
        }

        public CategoriesMultiList GetStatisticTree(string query)
        {
            var statisticTree = new CategoriesMultiList(new CategoryNode { Count = GetStatistic(query), Id = 0, Name = "/" });

            var listId = new List<int>();
            var attrId = new QueryCreator().Convert(query);
            listId.AddRange(attrId);

            AddChilds(statisticTree, listId);

            return statisticTree;
        }

        private static void AddChilds(CategoriesMultiList tree, List<int> listId)
        {
            

            var queryDocument = new QueryDocument(new BsonDocument { { "FatherRef", tree.Node.Id } });

            var childs = Attributes.FindAs<BsonDocument>(queryDocument).ToList();

            if (!childs.Any())
                return;

            foreach (var child in childs)
            {
                var list = new List<int>(listId);
                var childId = int.Parse(child["_id"].ToString());
                if(!list.Contains(childId))
                    list.Add(childId);
                 
                
                var node = new CategoryNode
                {
                    Count = GetStatistic(list),
                    Id = int.Parse(child["_id"].ToString()),
                    Name = child["Name"].ToString()
                };

                var subTree = new CategoriesMultiList(node);

                AddChilds(subTree, listId);

                tree.AddChild(subTree);
            }
        }

        

        private static Dictionary<string, List<string>> GetSecondaryFields(BsonDocument bsonBook)
        {
            var listOfAttributes = bsonBook.GetValue("Attributes");
            var listOfSecondaryFields = new Dictionary<string, List<string>>();


            foreach (var attribute in listOfAttributes.AsBsonArray)
            {
                var query = new QueryDocument("_id", attribute);

                var document = Attributes.FindOneAs<BsonDocument>(query);

                var id = document["RootRef"];
                query = new QueryDocument("_id", id);

                var secondaryField = Attributes.FindOneAs<BsonDocument>(query);

                if(secondaryField == null) continue;

                var name = secondaryField["Name"].ToString();
                var value = document["Name"].ToString();

                InsertKeyValuedPairIntoListOfSecondaryFields(listOfSecondaryFields, name, value);
            }

            return listOfSecondaryFields;
        }

        private static void InsertKeyValuedPairIntoListOfSecondaryFields(Dictionary<string, List<string>> listOfSecondaryFields, string name, string value)
        {
            if (listOfSecondaryFields.ContainsKey(name))
            {
                listOfSecondaryFields[name].Add(value);
            }
            else
            {
                listOfSecondaryFields.Add(name, new List<string> { value });
            }
        }

        private static List<Book> ConvertToBook(IEnumerable<BsonDocument> list)
        {
            var listBook = new List<Book>();

            foreach (var bsonBook in list)
            {
                var secondaryFields = GetSecondaryFields(bsonBook);

                listBook.Add(new Book
                                   {
                                       Name = bsonBook["Name"].ToString(),
                                       Md5Hash = bsonBook["_id"].ToString(),
                                       Path = bsonBook.Contains("Path") ? bsonBook["Path"].ToString() : null,
                                       SecondaryFields = secondaryFields
                                   }
                            );
            }

            return listBook;
        }
    }
}


