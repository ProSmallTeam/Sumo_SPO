using System.Collections.Generic;

namespace VisualSumoWPF
{
    public class Book
    {
        public string Name;

        public string Md5Hash;

        // путь к файлу, зависящий от пользователя
        public string Path;

        public Dictionary<string, List<string>> SecondaryFields;

        public Book(string name, string md5Hash, string path, Dictionary<string, List<string>> secondaryFields)
        {
            Name = name;
            Md5Hash = md5Hash;
            Path = path;
            SecondaryFields = secondaryFields;

        }

        public Book() : this("Пустой", "", "", new Dictionary<string, List<string>>())
        {
            
        }

    }
}