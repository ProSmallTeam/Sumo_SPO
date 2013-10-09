using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Test
{
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
