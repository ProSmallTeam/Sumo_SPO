using System.Collections.Generic;

namespace Sumo.API
{
    public class BookMeta
    {
        public string Name;

        public string Md5Hash;

        public string ISBN;

        public Dictionary<string, string> Attributes;

    }

    public class Book
    {
        public BookMeta Meta;

        public string PathToFile;
    }
}