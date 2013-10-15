using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataBase
{
    public interface IDataBase
    {
        void InsertBook(BookInformation book);
        void InsertSetting(BsonDocument setting);
        List<BsonDocument> Find(IMongoQuery query, MongoCollection collection);
        int GetStatistic(MongoCollection<BsonDocument> collection, BsonValue value);
    }
}