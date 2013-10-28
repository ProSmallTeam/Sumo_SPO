using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataBase
{
    internal static class Collections
    {
        // Коллекция, в которой хранится информация о книгах.
        public static MongoCollection<BsonDocument> Books;

        // Коллекция, в которой хранится всесь список аттрибутов.
        public static MongoCollection<BsonDocument> Attributes;

        public static MongoCollection<BsonDocument> Users;

        /*
        // Коллекция для хранения настроек
        public static MongoCollection<BsonDocument> Settings;
 
        // Коллекция, в которой хранится статистика по категориям.
        public static MongoCollection<BsonDocument> Category;

        // Коллекция, в которой хранится статистика по авторам.
        public static MongoCollection<BsonDocument> Authors;

        // Коллекция, в которой хранится статистика по годам.
        public static MongoCollection<BsonDocument> Years;

        

        public static Dictionary<string, MongoCollection<BsonDocument>> TypeOfCollection = new Dictionary<string, MongoCollection<BsonDocument>>();
         */
    }
}