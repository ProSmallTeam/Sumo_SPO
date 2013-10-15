using System.Collections.Generic;
using MongoDB.Bson;

namespace DataBase
{
    public class BookInformation
    {
        public string Name;

        public int YearOfPublication;

        public List<string> Category;

        public List<string> Authors;
    }
}