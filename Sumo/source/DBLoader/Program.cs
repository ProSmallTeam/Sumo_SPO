using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sumo.API;
using System.Xml.Linq;
using XmlBookConverter;


namespace DBLoader
{
    static class Program
    {
        /// <summary>
        /// Загружает информацию о кнагах из папки в базу данных.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var books = ReadFromFolder(args[1]);
            var manager = GetDBBookManager();

            var loader = new DBLoader(manager);

            loader.Save(books);
        }

        private static List<Book> ReadFromFolder(string pathToFolder)
        {
            var files = Directory.GetFiles(pathToFolder, "*.xml");

            return files.Select(XDocument.Load).Select(XmlBookConverter.XmlBookConverter.ToBook).ToList();
        }

        private static IDbBookManager GetDBBookManager()
        {
            throw new NotImplementedException();
        }
    }
}
