using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataBase.Test
{
    using System.Diagnostics;
    using NUnit.Framework;

    [TestFixture]
    public class DataBaseTest
    {
        private DataBase _database;

        private bool _flagOfInitializeDb;

        private const int NumberOfRecords = 1000000;

        [SetUp]
        public void SetUp()
        {
            _database = new DataBase("mongodb://localhost/?safe=false"); // получение объекта, с которым будем работать
           
            if (_flagOfInitializeDb)
            {
                return;
            }

            _flagOfInitializeDb = true;
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
            var query = new QueryDocument(true) {{"Attributes", 19}, {"Attributes", 63}};
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
            var book = _database.GetBooksByAttrId(new List<int> {5, 49});
            var name = book[1].Name;
            Trace.Write(name + '\n');
            Trace.Write(DateTime.Now - time);
        }

        [Test]
        public void TimeOfInsertOneBook()
        {
            var time = DateTime.Now;
            _database.SaveBookMeta(new Book{Md5Hash = "qwert", Name = "testBook", Path = null});
            Trace.Write(DateTime.Now - time);
        }

        [Test]
        public void TimeOfGettingStatisticByComplexAttr()
        {
            var time = DateTime.Now;

            _database.GetStatistic("Орин Томас, 1999");

            Trace.Write(DateTime.Now - time);
        }

        [Test]
        public void TimeOfGettingStatisticBySimpleAttr()
        {
            var time = DateTime.Now;

            _database.GetStatistic("Орин Томас");

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

            _database.Database.GetCollection("Attributes").Insert(new BsonDocument { { "_id", 0 }, { "Name", "Authors" } });
            _database.Database.GetCollection("Attributes").Insert(new BsonDocument { { "_id", 1 }, { "Name", "Year" } });

            foreach (var temp in authors)
                _database.Database.GetCollection("Attributes").Insert(new BsonDocument
                    {
                        {"_id", _database.Database.GetCollection("Attributes").Count()},
                        {"Name", temp},
                        {"RootRef", 0},
                        {"FatherRef", 0}
                    }
                    );

            for (var index = 1950; index < 2011; ++index)
                dataBase.Database.GetCollection("Attributes").Insert(new BsonDocument
                    {
                        {"_id", _database.Database.GetCollection("Attributes").Count()},
                        {"Name", index.ToString()},
                        {"RootRef", 1},
                        {"FatherRef", 1}
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
    
            var random = new Random();



            var time = DateTime.Now;

            for (var index = 0; index < numberOfRecords; ++index)
            {
                var listOfAltBook = new List<Book>();
                for (var indexes = 0; indexes < 5; ++indexes)
                {
                    listOfAltBook.Add(
                        new Book
                        {
                            Name = nameBook[random.Next(0, nameBook.Count() - 1)],
                            Md5Hash = indexes.ToString(),
                            Path = null,
                            SecondaryFields = new Dictionary<string, string>
                                        {
                                            {"Year", random.Next(1950, 2010).ToString()},
                                            {"Author", authors[random.Next(0, authors.Count() - 1)]}
                                        }
                        }
                            );
                }

                dataBase.SaveBookMeta(
                    new Book
                        {
                            Name = nameBook[random.Next(0, nameBook.Count() - 1)],
                            Md5Hash = index.ToString(),
                            Path = null,
                            SecondaryFields = new Dictionary<string, string>
                                {
                                    {"Year", random.Next(1950, 2010).ToString()},
                                    {"Author", authors[random.Next(0, authors.Count() - 1)]}
                                }
                        },
                        listOfAltBook
                    );
            }

            Trace.WriteLine(DateTime.Now - time);
        }
    }
}

