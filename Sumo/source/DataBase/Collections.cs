using MongoDB.Bson;
using MongoDB.Driver;

namespace DataBase
{
    internal static class Collections
    {
        // Коллекция, в которой хранится информация о книгах.
        public static MongoCollection<BsonDocument> Books;

        // Коллекция для хранения настроек
        public static MongoCollection<BsonDocument> Settings;
 
        // Коллекция, в которой хранится статистика по категориям.
        public static MongoCollection<BsonDocument> Category;

        // Коллекция, в которой хранится статистика по авторам.
        public static MongoCollection<BsonDocument> Authors;

        // Коллекция, в которой хранится статистика по годам.
        public static MongoCollection<BsonDocument> Years;

        public static MongoCollection<BsonDocument> Users;
    }
}