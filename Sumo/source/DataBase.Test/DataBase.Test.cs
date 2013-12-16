using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using Sumo.API;

namespace DataBase.Test
{
    using System.Diagnostics;
    using NUnit.Framework;

    [TestFixture]
    public class DataBaseTest
    {
        private DataBase _database;

        private const int NumberOfRecords = 1000;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _database = new DataBase("mongodb://localhost/?safe=false"); // получение объекта, с которым будем работать

            /*if (_database.Database.GetCollection("Books").Count() != 0)
            {
                return;
            }*/

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

            _database.Drop();

            InitializeAttr(_database);
            InitializeDb(_database, NumberOfRecords);
            _database.Indexing();
        }

        [Test]
        public void AssertOfUsingIndex()
        {
            var query = new QueryDocument(new BsonDocument{{"Attributes", 1}});

            Trace.Write(_database.Database.GetCollection("Books").Find(query));
        }

        [Test]
        public void AssertOfCorrectGetStatistic()
        {
            var query = new QueryDocument(true) { { "Attributes", 20 }, { "Attributes", 64 } };
            var result = _database.Database.GetCollection("Books").FindAs<BsonDocument>(query).Count(); ;
            Assert.AreEqual(
                result, 
                _database.GetStatistic("{Мэтью Мак-Дональд, 1991}")
                );
        }

        [Test]
        public void AssertOfCorrectDeletingBook()
        {
            _database.DeleteBookMeta("0");

            Assert.IsFalse(_database.IsHaveBookMeta("0"));
        }

        [Test]
        public void AssertOfGettingBook()
        {
            var time = DateTime.Now;
            var book = _database.GetBooks("1999, Г. Шмерлинг");
            string name = null;
            if (book != null)
                name = book[0].Name;
            Trace.Write(name + '\n');
            Trace.Write(DateTime.Now - time);

            WriteIntoFile("Время выборки книг по заданным id: " + (DateTime.Now - time));
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
        public void AssertOfCorrectInsertTask()
        {
            _database.InsertTask(new Task { PathToFile = "path0" });

            Assert.IsNotEmpty(_database.Database.GetCollection<BsonDocument>("Tasks").FindAs<BsonDocument>(new QueryDocument(new BsonDocument{{"Path", "path0"}})).ToArray());
        }

        [Test]
        public void AssetOfGettingTaskList()
        {
            Assert.IsNotEmpty(_database.GetTask(20));
        }

        [Test]
        public void AssertOfCorrectGettingTaskList()
        {
            const int QuantityOfTask = 100;

            _database.GetTask(QuantityOfTask);
            Assert.IsEmpty(_database.GetTask(1));
        }

        [Test]
        public void AssertOfCorrectGetStaticticTree()
        {
            var time = DateTime.Now;

            var result = _database.GetStatisticTree("2005");

            Trace.Write(DateTime.Now - time);
           
        }

        private void InitializeAttr(DataBase dataBase)
        {
            var authors = new[]
                {
                    "Дмитрий Макарский", "М. Ховард", " М. Леви", "Р. Вэймир", "Г. Шмерлинг", "Трев Уилкинс", "В. А. Жарков",
                    "Йен Маклин", "Орин Томас",
                    "Джон Гудсон", "Бен Харвелл", "Бен Харвелл", "Том Уайт", "Евгения Пастернак", "Марина Виннер",
                    "Майкл Фриман", "Кристиан Уэнц",
                    "Мэтью Мак-Дональд", "Д. Н. Колисниченко", "Андрей Грачев"
                };

            _database.Database.GetCollection("Attributes").Insert(new BsonDocument { { "_id", 1 }, { "Name", "Authors" }, { "RootRef", 0 }, { "FatherRef", 0 } });
            _database.Database.GetCollection("Attributes").Insert(new BsonDocument { { "_id", 2 }, { "Name", "Year" }, { "RootRef", 0 }, { "FatherRef", 0 } });

            foreach (var temp in authors)
                _database.Database.GetCollection("Attributes").Insert(new BsonDocument
                    {
                        {"_id", _database.Database.GetCollection("Attributes").Count() + 1},
                        {"Name", temp},
                        {"RootRef", 1},
                        {"FatherRef", 1}
                    }
                    );

            for (var index = 1950; index < 2011; ++index)
                dataBase.Database.GetCollection("Attributes").Insert(new BsonDocument
                    {
                        {"_id", _database.Database.GetCollection("Attributes").Count() + 1},
                        {"Name", index.ToString()},
                        {"RootRef", 2},
                        {"FatherRef", 2}
                    }
                    );
        }

        private static void InitializeDb(DataBase dataBase, int numberOfRecords)
        {
           var nameBook = new[]
                               {
                                   "C", "C++", "C#", "Java", "PHP", "JavaScript", "Assembler", "AutoCAD Civil 3D 2013. Официальный учебный курс", "25 этюдов о шифрах",
                                   "Яндекс Воложа. История создания компании мечты", "Изучаем HTML, XHTML", " Самоучитель работы на ПК для всех",
                                   "Журнал CHIP, сентябрь №9/2013", "Интернет-программирование на Java", "Компьютер для женщин"
                               };
            var authors = new[]
                              {
                                  "Дмитрий Макарский", "М. Ховард", " М. Леви", "Р. Вэймир", "Г. Шмерлинг", "Трев Уилкинс", "В. А. Жарков", "Йен Маклин", "Орин Томас",
                                  "Джон Гудсон", "Бен Харвелл", "Бен Харвелл", "Том Уайт", "Евгения Пастернак", "Марина Виннер", "Майкл Фриман", "Кристиан Уэнц",
                                  "Мэтью Мак-Дональд", "Д. Н. Колисниченко", "Андрей Грачев"
                              };
            var language = new[] { "Russian", "English" };
            var arrayOfPriority = new[] { true, false };

            var random = new Random();



            var time = DateTime.Now;

            for (var index = 0; index < numberOfRecords; ++index)
            {
                var listOfAltBook = new List<Sumo.API.Book>();
                for (var indexes = 0; indexes < 5; ++indexes)
                {
                    listOfAltBook.Add(
                        new Sumo.API.Book
                        {
                            Name = nameBook[random.Next(0, nameBook.Count() - 1)],
                            Md5Hash = indexes.ToString(),
                            Path = null,
                            SecondaryFields = new Dictionary<string, List<string>>
                                        {
                                            {"Year", new List<string>{random.Next(1950, 2010).ToString()}},
                                            {"Author", new List<string>{authors[random.Next(0, authors.Count() - 1)]}}
                                        }
                        }
                            );
                }

                dataBase.SaveBookMeta(
                    new Sumo.API.Book()
                        {
                            Name = nameBook[random.Next(0, nameBook.Count() - 1)],
                            Md5Hash = index.ToString(),
                            Path = null,
                            SecondaryFields = new Dictionary<string, List<string>>
                                {
                                    {"Year", new List<string>{random.Next(1950, 2010).ToString()}},
                                    {"Author", new List<string>{authors[random.Next(0, authors.Count() - 1)], authors[random.Next(0, authors.Count() - 1)]}}
                                }
                        },
                        listOfAltBook
                    );
            }

            for (var index = 0; index < 100; index++)
            {
                var task = new Task { PathToFile = "path" + index };
                var priority = arrayOfPriority[index % 2];

                dataBase.InsertTask(task, priority);
            }
            

            Trace.WriteLine(DateTime.Now - time);
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

