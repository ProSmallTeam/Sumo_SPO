using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBase
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class DataBase : IDataBase
    {
        public readonly MongoDatabase Database;

        private const string NameOfDataBase = "library";

        private const string BookCollection = "Books";

        private const string SettingsCollection = "Settings";

        private const string CategoryCollection = "Category";

        public DataBase(string connectiongString)
        {
            var server = MongoServer.Create(connectiongString);

            Database = server.GetDatabase(NameOfDataBase);
        }

        public List<BsonDocument> Find(IMongoQuery query, MongoCollection collection)
        {
            return collection.FindAs<BsonDocument>(query).ToList();
        }

        private static void Insert(BsonDocument document, MongoCollection collection)
        {
            collection.Insert(document);
        }

        public void InsertBook(BsonDocument book)
        {
            Insert(book, Database.GetCollection(BookCollection));
        }

        public void InsertSetting(BsonDocument setting)
        {
            //поиск данной настройки
            Insert(setting, Database.GetCollection(SettingsCollection));
        }

        public void InsertCategory(string nameOfCategory)
        {
            var collection = Database.GetCollection(CategoryCollection);
            var query = Query.EQ("name", nameOfCategory);

            var match = Find(query, collection);  

            if (match.Count != 0)
                throw new Exception();

            var category = new BsonDocument {{"name", nameOfCategory}};
            
            Insert(category, collection);
        }

        public long GetStatistic(string name, string value)
        {
            var query = Query.EQ(name, value);
            return Find(query, Database.GetCollection(BookCollection)).Count;
        }
        
        public long GetCountOfBooks()
        {
            return Database.GetCollection(BookCollection).Count();
        }

        public void Drop()
        {
            Database.Drop();
        }
    }
}
