using System.Collections.Generic;
using System.Linq;
using Sumo.API;

namespace DBLoader
{
    internal class DBLoader
    {
        private readonly IDbBookManager _manager;

        public DBLoader(IDbBookManager manager)
        {
            _manager = manager;
        }

        public void Save(List<Book> listOfBook)
        {
            const int indexOfMainBook = 0;
            var mainBook = listOfBook[indexOfMainBook];

            var listOfAltMeta = new List<Book>();

            for (var indexOfAltMeta = 1; indexOfAltMeta < listOfBook.Count(); indexOfAltMeta++)
            {
                var altMeta = listOfBook[indexOfAltMeta];
                listOfAltMeta.Add(altMeta);
            }

            _manager.Save(mainBook, listOfAltMeta);
        }
    }
}
