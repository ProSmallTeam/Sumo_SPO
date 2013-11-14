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

        // КоллекцияЮ в которой хранятся пути к файлам, зависящие от пользователя.
        public static MongoCollection<BsonDocument> Users;

        // Коллекция, в которой хранятся прочие данные о книгах.
        public static MongoCollection<BsonDocument> AlternativeMeta;
    }
}