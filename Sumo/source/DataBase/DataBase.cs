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
        public MongoDatabase Database;

        private const string NameOfDataBase = "library";

        public DataBase(string connectiongString)
        {
            var server = MongoServer.Create(connectiongString);

            Database = server.GetDatabase(NameOfDataBase);

            SetCollections();
        }

        private void SetCollections()
        {
            Collections.Books = Database.GetCollection<BsonDocument>("Books");
            Collections.Settings = Database.GetCollection<BsonDocument>("Settings");

            Collections.Category = Database.GetCollection<BsonDocument>("Category");
            Collections.Authors = Database.GetCollection<BsonDocument>("Authors");
            Collections.Years = Database.GetCollection<BsonDocument>("Years");
            
        }

        public List<BsonDocument> Find(IMongoQuery query, MongoCollection collection)
        {
            return collection.FindAs<BsonDocument>(query).ToList();
        }

        private static void Insert(BsonDocument document, MongoCollection collection)
        {
            collection.Insert(document);
        }

        public void InsertBook(BookInformation book)
        {
            Insert(book.ToBsonDocument(), Collections.Books);
            UpdateStatistic(book);
        }

        private static void UpdateStatistic(BookInformation bookInformation)
        {
            Update(Collections.Years, bookInformation.YearOfPublication);
            
            foreach (var category in bookInformation.Category)
            {
                Update(Collections.Category, category);
            }

            foreach (var author in bookInformation.Authors)
            {
                Update(Collections.Authors, author);
            }
            
        }

        private static void Update(MongoCollection<BsonDocument> collection, BsonValue updateValue)
        {
            var query = new QueryDocument(new BsonDocument { { "_id", updateValue } });

            var result = collection.Find(new QueryDocument(query));

            if (!result.Any())
                collection.Insert(new BsonDocument
                    {
                        {"_id", updateValue},
                        {"Statistic", 1}
                    });
            else
            {
                var update = MongoDB.Driver.Builders.Update.Inc("Statistic", 1);
                collection.Update(query, update);
            }
        }

        public void InsertSetting(BsonDocument setting)
        {
            Insert(setting, Collections.Settings);
        }

        public int GetStatistic(MongoCollection<BsonDocument> collection, BsonValue value)
        {
            var query = new QueryDocument(new BsonDocument{{"_id", value}});

            var find = collection.FindOne(query);

            var subStringIndex = "Statistic".Length + 1;

            var statisticString = find.GetElement("Statistic").ToString();

            var result = int.Parse(statisticString.Substring(subStringIndex));

            return result;
        }
        
        public void Indexing(string name)
        {
            Collections.Books.EnsureIndex(new[] { name });
        }

        public void Drop()
        {
            Database.Drop();
        }
    }
}
