using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DB
{
    internal static class Collections
    {
        // Коллекция, в которой хранится информация о книгах.
        public static MongoCollection<BsonDocument> Books;

        // Коллекция, в которой хранится всесь список аттрибутов.
        public static MongoCollection<BsonDocument> Attributes;

        // Коллекция, в которой хранятся пути к файлам, зависящие от пользователя.
        //public static MongoCollection<BsonDocument> Users;

        // Коллекция, в которой хранятся прочие данные о книгах.
        public static MongoCollection<BsonDocument> AlternativeMeta;

        // Колекция, в которой хранятся задания на обработку книг.
        public static MongoCollection<BsonDocument> Tasks;
    }
}