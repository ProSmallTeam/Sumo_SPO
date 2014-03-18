using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using Sumo.API;

namespace DB.Test
{
    using System.Diagnostics;
    using NUnit.Framework;

    [TestFixture]
    public class DataBaseTest
    {
        private DataBase _database;

        private const int NumberOfRecords = 5;

        [TestFixtureSetUp]
        public void CreateDB()
        {
            _database = new DataBase("mongodb://localhost/?safe=false"); // получение объекта, с которым будем работать

            EnviromentInfo();
        }

        

        [SetUp]
        public void SetUp()
        {
            IntializeDataBase.Initialize(_database, NumberOfRecords);
        }

        [Test]
        public void UsingIndex()
        {
            var query = new QueryDocument(new BsonDocument{{"Attributes", 1}});

            Trace.Write(_database.Database.GetCollection("Books").Find(query));
        }

        [Test]
        public void GetStatistics()
        {
            var query = new QueryDocument(true) { { "Attributes", 19 }, { "Attributes", 63 } };

            var result = _database.Database.GetCollection("Books").FindAs<BsonDocument>(query).Count(); ;
            Assert.AreEqual(
                result, 
                _database.GetStatistic("{Мак-Дональд, 1991}")
                );
        }

        [Test]
        public void RemoveBook()
        {
            _database.DeleteBookMeta("0");

            Assert.IsFalse(_database.IsHaveBookMeta("0"));
        }

        [Test]
        public void GetBook()
        {
            var time = DateTime.Now;
            var book = _database.GetBooks("2010, Макарский");
            string name = null;
            if (book != null)
                name = book[0].Name;
            Trace.Write(name + '\n');
            Trace.Write(DateTime.Now - time);

            WriteIntoFile("Время выборки книг по заданным id: " + (DateTime.Now - time));
        }

        [Test]
        public void GetAllBooks()
        {
            Assert.AreEqual(NumberOfRecords, _database.GetBooks("").Count);
        }

        [Test]
        public void TimeOfInsertOneBook()
        {
            var time = DateTime.Now;
            _database.SaveBookMeta(new Sumo.API.Book{Md5Hash = "qwert", Name = "testBook", Path = null});
            Trace.Write(DateTime.Now - time);

            WriteIntoFile("Время вставки одной книги: " + (DateTime.Now - time));
        }

        [Test]
        public void TimeOfGettingStatisticByComplexAttr()
        {
            var time = DateTime.Now;

            _database.GetStatistic("Орин Томас, 1999");

            Trace.Write(DateTime.Now - time);

            WriteIntoFile("Время подсчета статистики по двум аттрибуту: " + (DateTime.Now - time));
        }

        [Test]
        public void TimeOfGettingStatisticBySimpleAttr()
        {
            var time = DateTime.Now;

            _database.GetStatistic("Орин Томас");

            Trace.Write(DateTime.Now - time);

            WriteIntoFile("Время подсчета статистики по одному аттрибуту: " + (DateTime.Now - time));
        }

        [Test]
        public void InsertTask()
        {
            _database.InsertTask(new Task { PathToFile = "path0" });

            Assert.IsNotEmpty(_database.Database.GetCollection<BsonDocument>("Tasks").FindAs<BsonDocument>(new QueryDocument(new BsonDocument{{"Path", "path0"}})).ToArray());
        }

        [Test]
        public void GetTaskList()
        {
            Assert.IsNotEmpty(_database.GetTask(20));
        }

        [Test]
        public void GetEmptyTaskList()
        {
            const int QuantityOfTask = 100;

            _database.GetTask(QuantityOfTask);
            Assert.IsEmpty(_database.GetTask(1));
        }

        [Test]
        public void GetStatisticTree()
        {
            var time = DateTime.Now;

            var res = _database.GetBooks("");

            var result = _database.GetStatisticTree("");

            Trace.Write(DateTime.Now - time);
           
        }

        private static void EnviromentInfo()
        {
            var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            WriteIntoFile("------------- Процессор: ---------------");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                WriteIntoFile("Наименование: " + queryObj["Name"]);
                WriteIntoFile("Количество ядер: " + queryObj["NumberOfCores"]);
            }

            searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");

            WriteIntoFile("------------- Оперативная память: --------");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                WriteIntoFile("Маркировка: " + queryObj["BankLabel"]);
                WriteIntoFile("Размер: " + Math.Round(Convert.ToDouble(queryObj["Capacity"]) / 1024 / 1024 / 1024, 2) + " Gb");
                WriteIntoFile("Скорость: " + queryObj["Speed"]);
            }

            searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");

            WriteIntoFile("------------- Операционная система: --------");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                WriteIntoFile("Название: " + queryObj["Name"]);
                WriteIntoFile("Версия: " + queryObj["Version"]);
            }

            WriteIntoFile("------------- Количество записей в базе данных: --------");
            WriteIntoFile(NumberOfRecords.ToString());
            WriteIntoFile("\n");
        }
        
        private static void WriteIntoFile(string result)
        {
            var path = "result" + "(" + DateTime.Today.ToShortDateString() + ")" + ".txt";
            var fileInfo = new FileInfo(path);
            var streamWriter = fileInfo.AppendText();
            streamWriter.WriteLine(result);
            streamWriter.Close();
        }
    }
}

