using System;
using System.Collections.Generic;
using System.IO;
using Sumo.API;
using System.Xml.Linq;


namespace DBLoader
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            const int pathToFolder = 1;

            var listOfBook = ReadFromFolder(args[pathToFolder]);
            var manager = GetDBBookManager();

            var loader = new DBLoader(manager);
            
            loader.Save(listOfBook);
        }

        private static List<Book> ReadFromFolder(string pathToFolder)
        {
            var listOfBook = new List<Book>();
            var files = Directory.GetFiles(pathToFolder, "*.xml");

            foreach (var pathToFile in files)
            {
                var xml = XDocument.Load(pathToFile);
                var book = XmlBookConverter.XmlBookConverter.XmlToBook(xml);

                listOfBook.Add(book);
            }

            return listOfBook;
        }

        private static IDbBookManager GetDBBookManager()
        {
            throw new NotImplementedException();
        }
    }
}
