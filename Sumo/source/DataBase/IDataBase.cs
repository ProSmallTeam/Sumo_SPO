using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataBase
{
    public interface IDataBase
    {
        void InsertBook(BsonDocument book);
        void InsertSetting(BsonDocument setting);
        void InsertCategory(string category);
        List<BsonDocument> Find(IMongoQuery query, MongoCollection collection);
        long GetStatistic(string name, string value);
    }
}