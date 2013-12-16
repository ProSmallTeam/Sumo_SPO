using System;
using System.Collections.Generic;
using System.Linq;
using Sumo.API;

namespace DataBase
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class DataBase : IDataBase
    {
        public MongoDatabase Database;

        private readonly string _nameOfDataBase;

        public DataBase(string connectiongString, string nameOfDataBase = "library")
        {
            var client = new MongoClient(connectiongString);
            var server = client.GetServer();

            _nameOfDataBase = nameOfDataBase;

            Database = server.GetDatabase(_nameOfDataBase);

            SetCollections();
        }

        private void SetCollections()
        {
            Collections.Books = Database.GetCollection<BsonDocument>("Books");

            Collections.Attributes = Database.GetCollection<BsonDocument>("Attributes");

            Collections.AlternativeMeta = Database.GetCollection<BsonDocument>("AlternativeMeta");

            Collections.Tasks = Database.GetCollection<BsonDocument>("Tasks");

        }

        public List<BsonDocument> Find(IMongoQuery query, MongoCollection collection)
        {
            return collection.FindAs<BsonDocument>(query).ToList();
        }

        public void Indexing()
        {
            Collections.Books.EnsureIndex(new IndexKeysBuilder().Ascending("Attributes"));
            Collections.Attributes.EnsureIndex(new IndexKeysBuilder().Ascending("_id"));
            Collections.AlternativeMeta.EnsureIndex(new IndexKeysBuilder().Ascending("_id"));
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
                    foreach (var altBookMeta in alternativeBook.Select(altBook => CreateBook(altBook, Collections.AlternativeMeta)))
                    {
                        Collections.AlternativeMeta.Insert(altBookMeta);

                        idOfAltMeta.Add(int.Parse(altBookMeta["_id"].ToString()));
                    }

                var document = CreateBook(book, Collections.Books, idOfAltMeta);

                Collections.Books.Insert(document);

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

                var book = Collections.Books.FindOneAs<BsonDocument>(query);

                Collections.Books.Remove(query);

                var stringOfid = book["AlternativeMeta"].ToString();
                var idOfAltMeta = stringOfid
                                           .Substring(1, stringOfid.Length - 2)
                                           .Split(new[] { ',' }).ToList();

                foreach (var id in idOfAltMeta)
                {
                    query = new QueryDocument(new BsonDocument { { "_id", int.Parse(id) } });

                    Collections.AlternativeMeta.Remove(query);

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
            foreach (var attribute in from field
                                          in book.SecondaryFields
                                      from nameOfAttribute
                                          in field.Value
                                      select new QueryDocument(new BsonDocument { { "Name", nameOfAttribute } })
                                          into query
                                          select Collections.Attributes.FindOneAs<BsonDocument>(query))
            {
                if (attribute == null)
                    throw new NoAttrException();

                attributes.Add(int.Parse(attribute["_id"].ToString()));
            }

            return attributes;
        }

        public bool IsHaveBookMeta(string md5Hash)
        {
            return Collections.Books.Find(new QueryDocument(new BsonDocument { { "Md5Hash", md5Hash } })).Any();
        }

        public int GetStatistic(string query)
        {
            var attrId = new QueryCreator().Convert(query);

            return GetStatistic(attrId);
        }

        public List<Book> GetBooks(string query, int limit = 0, int offset = 0)
        {
            var attrId = new QueryCreator().Convert(query);

            return GetBooksByAttrId(attrId, limit, offset);
        }

        public int GetStatistic(List<int> attrId)
        {
            var queries = new QueryDocument(true);

            foreach (var id in attrId)
            {
                queries.Add("Attributes", id).AsParallel();
            }

            return (int)Collections.Books.FindAs<BsonDocument>(queries).Count();
        }

        private List<Book> GetBooksByAttrId(List<int> attrId, int limit = 0, int offset = 0)
        {
            var query = new QueryDocument(true);

            foreach (var id in attrId)
            {
                query.Add("Attributes", id).AsParallel();
            }

            return ConvertToBook(Collections.Books.FindAs<BsonDocument>(query).SetLimit(limit).SetSkip(offset).ToList());
        }

        public int SaveAttribute(string name, int parrentId, int rootId)
        {
            var IsRoot = rootId == null;

            try
            {
                Collections.Attributes.Insert(new BsonDocument
                    {
                        {"_id", Collections.Attributes.Count()},
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
            var priority = flagOfHighPriority ? 1 : 0;
            
            var _task = new BsonDocument
                                     {
                                         {"Path", task.PathToFile}, 
                                         {"Priority", priority}, 
                                         {"Receipt", false}
                                     };
            try
            {
                Collections.Tasks.Insert(_task);

                return 0;
            }
            catch (Exception)
            {
                
                return  -1;
            }
        }

        public int RemoveTask(Task task)
        {
            var query = new QueryDocument(new BsonDocument { { "Path", task.PathToFile } });
            
            try
            {
                Collections.Tasks.Remove(query);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public List<Task> GetTask(int quantity)
        {
            const int HighPriority = 1;
            const int LowPriority = 0;

            var query = new QueryDocument(new BsonDocument { { "Priority", HighPriority }, { "Receipt", false } });
            var tempList = Collections.Tasks.FindAs<BsonDocument>(query).SetLimit(quantity).ToList();

            var result = tempList.Select(task => new Task { PathToFile = task["Path"].ToString() }).ToList();

            var count = result.Count;

            if (count < quantity)
            {
                query = new QueryDocument(new BsonDocument { { "Priority", LowPriority }, { "Receipt", false } });
                tempList = Collections.Tasks.FindAs<BsonDocument>(query).SetLimit(quantity - count).ToList();

                result.AddRange(tempList.Select(task => new Task { PathToFile = task["Path"].ToString() }));
            }

            UpdateTask(result);

            return result;
        }

        public CategoriesMultiList GetStatisticTree(string query)
        {
            var statisticTree = new CategoriesMultiList(new CategoryNode { Count = (int)Collections.Books.FindAll().Count(), Id = 0, Name = "/" });

            AddChilds(statisticTree, query);

            return statisticTree;
        }

        private static void AddChilds(CategoriesMultiList tree, string query)
        {
            var queryDocument = new QueryDocument(new BsonDocument { { "FatherRef", tree.Node.Id } });

            var childs = Collections.Attributes.FindAs<BsonDocument>(queryDocument).ToList();

            if (!childs.Any())
                return;

            foreach (var child in childs)
            {
                var node = new CategoryNode
                {
                    Count = 1,
                    Id = int.Parse(child["_id"].ToString()),
                    Name = child["Name"].ToString()
                };

                var subTree = new CategoriesMultiList(node);

                AddChilds(subTree, query);

                tree.AddChild(subTree);
            }
        }

        private static void UpdateTask(IEnumerable<Task> tasks)
        {
            var update = Update.Set("Receipt", true);
            foreach (var query in tasks.Select(task => new QueryDocument(new BsonDocument { {"Path", task.PathToFile} })))
            {
                Collections.Tasks.Update(query, update, UpdateFlags.Multi);
            }
        }

        private static Dictionary<string, List<string>> GetSecondaryFields(BsonDocument bsonBook)
        {
            var listOfAttributes = bsonBook.GetValue("Attributes");
            var listOfSecondaryFields = new Dictionary<string, List<string>>();


            foreach (var attribute in listOfAttributes.AsBsonArray)
            {
                var query = new QueryDocument("_id", attribute);

                var document = Collections.Attributes.FindOneAs<BsonDocument>(query);

                var id = document["RootRef"];
                query = new QueryDocument("_id", id);

                var name = Collections.Attributes.FindOneAs<BsonDocument>(query)["Name"].ToString();

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


