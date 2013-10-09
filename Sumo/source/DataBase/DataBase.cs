using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class DataBase
    {
        public readonly MongoDatabase database;

        private const string NameOfDataBase = "library";

        private MongoCollection<BsonDocument> currentCollection { get; set; }

        public DataBase(string connectiongString)
        {
            var server = MongoServer.Create(connectiongString);

            database = server.GetDatabase(NameOfDataBase);
        }

        public void SetCollection(string collection)
        {
            currentCollection = database.GetCollection<BsonDocument>(collection);
        }

        public List<BsonDocument> Find(IMongoQuery query)
        {
            return currentCollection.FindAs<BsonDocument>(query).ToList();
        }

        public void Insert(BsonDocument document)
        {
            currentCollection.Insert(document);
        }

        public long GetStatistic(string name, string value)
        {
            var query = Query.EQ(name, value);
            return this.Find(query).Count;
        }
        
        public long GetCountOfBooks()
        {
            return database.GetCollection("Books").Count();
        }

        public void Drop()
        {
            database.Drop();
        }
    }
}
