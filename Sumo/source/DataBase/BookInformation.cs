namespace InitializeDataBase
{
    using System.Collections.Generic;

    public class BookInformation : IBookInformation
    {

        public string Name;

        public string ISBN;

        public List<string> Authors;

        public int YearOfPublication;

        public int CountOfPages;

        public string Language;

        public string Edition;

    }
}