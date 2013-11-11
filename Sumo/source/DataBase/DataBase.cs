using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBase
{
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class DataBase : IDataBase
    {
        public MongoDatabase Database;

        private string NameOfDataBase;

        public DataBase(string connectiongString, string nameOfDataBase = "library")
        {
            var server = MongoServer.Create(connectiongString);
            NameOfDataBase = nameOfDataBase;

            Database = server.GetDatabase(NameOfDataBase);

            SetCollections();
        }

        private void SetCollections()
        {
            Collections.Books = Database.GetCollection<BsonDocument>("Books");

            Collections.Attributes = Database.GetCollection<BsonDocument>("Attributes");

        }

        public List<BsonDocument> Find(IMongoQuery query, MongoCollection collection)
        {
            return collection.FindAs<BsonDocument>(query).ToList();
        }

        public void Indexing(string name)
        {
            Collections.Books.EnsureIndex(new[] { name });
        }

        public void Drop()
        {
            Database.Drop();
        }

        public void SaveBookMeta(Book book)
        {
            

            var attributes = new List<int>();

            if (book.SecondaryFields != null)
                foreach (var attribute in book.SecondaryFields.Select(field => new QueryDocument(new BsonDocument {{"Name", field.Value}})).Select(query => Collections.Attributes.FindOneAs<BsonDocument>(query)))
                {
                    if (attribute == null)
                        throw new NoAttrException();

                    attributes.Add(int.Parse(attribute["_id"].ToString()));
                }

            var document = new BsonDocument
                {
                    {"_id", book.Md5Hash}, 
                    {"Name", book.Name}, 
                    {"Path", book.Path}, //место подключения поддержки различных пользователей
                    {"Attributes", new BsonArray(attributes)}
                };

            Collections.Books.Insert(document);
        }

        public bool IsHaveBookMeta(string md5Hash)
        {
            return Collections.Books.Find(new QueryDocument(new BsonDocument { { "Md5Hash", md5Hash } })).Any();
        }

        public int GetStatistic(string query)
        {
            var stringQuery = query.Split(new[] { ", ", "{", "}" }, StringSplitOptions.RemoveEmptyEntries);

            var attrId = (from nameAttr in stringQuery select new QueryDocument(new BsonDocument {{"Name", nameAttr}}) into queryDocument select Collections.Attributes.FindOneAs<BsonDocument>(queryDocument) into attr select int.Parse(attr["_id"].ToString())).ToList();

            var queries = new QueryDocument(true);

            foreach (var id in attrId)
            {
                queries.Add("Attributes", id).AsParallel();
            }

            return (int) Collections.Books.FindAs<BsonDocument>(queries).Count();
        }

        public IList<Book> GetBooksByAttrId(List<int> attrId, int limit = 0, int offset = 0)
        {
            var query = new QueryDocument(true);
            
            foreach (var id in attrId)
            {
                query.Add("Attributes", id).AsParallel();
            }

            return ConvertToBook(Collections.Books.FindAs<BsonDocument>(query).SetLimit(limit).SetSkip(offset).ToList());
        }

        public void SaveAttribute(string name, int parrentId, int rootId)
        {
            throw new NotImplementedException();
        }


        private static Dictionary<string, string> GetSecondaryFields(BsonDocument bsonBook)
        {
            var listOfAttributes = bsonBook.GetValue("Attributes");
            var listOfSecondaryFields = new Dictionary<string, string>();
         
            foreach(var attribute in listOfAttributes.AsBsonArray)
            {
                var query = new QueryDocument("_id", attribute);

                var document = Collections.Attributes.FindOneAs<BsonDocument>(query);
                
                var id = document["RootRef"];
                query = new QueryDocument("_id", id);

                var name = Collections.Attributes.FindOneAs<BsonDocument>(query)["Name"].ToString();

                var value = document["Name"].ToString();

                listOfSecondaryFields.Add(name, value);
            }

            return listOfSecondaryFields;
        }


        private static IList<Book> ConvertToBook(IEnumerable<BsonDocument> list)
        {
            IList<Book> listBook = new List<Book>();
            

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


