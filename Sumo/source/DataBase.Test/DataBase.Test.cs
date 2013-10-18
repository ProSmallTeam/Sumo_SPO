using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DataBase.Test
{
    using System.Diagnostics;
    using System.Globalization;
    using MongoDB.Driver.Builders;
    using NUnit.Framework;

    [TestFixture]
    public class DataBaseTest
    {
        private DataBase database;

        private readonly int numberOfRecords = 10000;
       
        [SetUp]
        public void SetUp()
        {
            database = new DataBase("mongodb://localhost/?safe=true"); // получение объекта, с которым будем работать
        }

        [Ignore]
        [Test]
        public void AssertOfCorrectInitialize()
        {
            database.Drop();
            this.InitializeDb();
            Assert.AreEqual(numberOfRecords, database.Database.GetCollection("Books"));
        }

        [Test]
        public void AssertOfCorrectExecuteQueryByYearOfPublication()
        {
            var query = Query.EQ("YearOfPublication", 2000);

            var result = database.Find(query, database.Database.GetCollection("Books"));
           
            Assert.AreEqual(88, result.Count());
        }

        [Test]
        public void AssertOfCorrectExecuteQueryByAuthor()
        {
            var query = Query.EQ("Authors", "Марина Виннер");

            var result = database.Find(query, database.Database.GetCollection("Books"));

            Assert.AreEqual(493, result.Count());
        }

        [Test]
        public void CorrectOfGettingStatisticByYear()
        {
            Assert.AreEqual(85, database.GetStatistic("Years", "1982"));
        }

        [Test]
        public void CorrectOfGettingStatisticByAuthor()
        {
            Assert.AreEqual(498, database.GetStatistic("Authors", "Дмитрий Макарский"));
        }

        [Test]
        public void CorrectOfGettingStatisticByCategory()
        {
            Assert.AreEqual(10000, database.GetStatistic("Category", "Tex"));
        }

        [Test]
        public void Indexing()
        {
            database.Indexing("Name");
            database.Indexing("Year");
        }

        private void InitializeDb()
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
                database.InsertBook(
                    new BookInformation
                        {
                            Name = nameBook[random.Next(0, 14)],
                            Category = new List<string>(new[] { "Tex", "ABC" }),
                            YearOfPublication = random.Next(1900, 2015),
                            Authors = new List<string>
                                {
                                    authors[random.Next(0, 19)]
                                }
                        }
                    );
            }
       
            Trace.WriteLine(DateTime.Now - time);
        }
    }
}

