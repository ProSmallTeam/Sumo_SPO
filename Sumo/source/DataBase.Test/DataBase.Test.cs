using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Test
{
    using System.Diagnostics;
    using System.Globalization;

    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Bson;

    using NUnit.Framework;

    [TestFixture]
    public class DataBaseTest
    {
        private DataBase database;

        private MongoCollection<BsonDocument> collection;

        private readonly int numberOfRecords = 10000;
       
        [SetUp]
        public void SetUp()
        {
            database = new DataBase("mongodb://localhost/?safe=true"); // получение объекта, с которым будем работать

            database.SetCollection("Books"); // получение ссылки на колекцию, то есть создание новой
        }

        [Ignore]
        [Test]
        public void AssertOfCorrectInitialize()
        {
            database.Drop();
            this.InitializeDB();
            Assert.AreEqual(numberOfRecords, database.GetCountOfBooks());
        }

        [Test]
        public void AssertOfCorrectExecuteQuery()
        {
            var query = Query.And
                (
                    Query.GTE("BookInformation.YearOfPublication", 2000),
                    Query.EQ("BookInformation.Language", "Russian")
                );

            var result = database.Find(query);
           
            Assert.AreEqual(613, result.Count());
        }

        private void InitializeDB()
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
                database.Insert(
                    new Book
                        {
                            _id = index.ToString(),
                            BookInformation =
                                new BookInformation
                                    {
                                        Name = nameBook[random.Next(0, 14)],
                                        CountOfPages = random.Next(90, 500) + 100,
                                        ISBN = random.Next(100000000, 999999999).ToString(CultureInfo.InvariantCulture),
                                        YearOfPublication = random.Next(1900, 2014),
                                        Authors = new List<string>(new[] { authors[random.Next(0, 19)], authors[random.Next(0, 19)] }),
                                        Language = language[index % 2],
                                        Edition = "Цифровая книга"
                                    },
                            Attribute =
                                new Attribute
                                    {
                                        ReferenceToTheBook = @"C:\Users\Documents\GitHub\Sumo_SPO\" + random.Next(0, 14) + ".pdf",
                                        fileExtension = "pdf",
                                        Categories = new List<string>(new[] { "Tex" })
                                    }
                        }.ToBsonDocument());
            }

            Trace.WriteLine(DateTime.Now - time);
        }
    }
}
