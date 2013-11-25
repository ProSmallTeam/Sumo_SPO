using System.Collections.Generic;
using MongoDB.Bson;

namespace DataBase
{
    public class Book
    {
        public string Name;

        public string Md5Hash;

        // путь к файлу, зависящий от пользователя
        public string Path;

        public Dictionary<string, string> SecondaryFields;
    }
}