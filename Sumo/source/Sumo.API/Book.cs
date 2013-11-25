using System.Collections.Generic;

namespace Sumo.API
{
    public class Book
    {
        public string Name;

        public string Md5Hash;

        // путь к файлу, зависящий от пользователя
        public string Path;

        public Dictionary<string, List<string>> SecondaryFields;
    }
}