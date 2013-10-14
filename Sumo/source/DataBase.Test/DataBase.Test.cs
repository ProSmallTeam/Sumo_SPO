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

        //[Ignore]
        [Test]
        public void AssertOfCorrectInitialize()
        {
            database.Drop();
            this.InitializeDb();
            Assert.AreEqual(numberOfRecords, database.GetCountOfBooks());
        }

        [Test]
        public void AssertOfCorrectExecuteQuery()
        {
            var query = Query.And
                (
                    Query.GTE("PublishYear", 2000),
                    Query.EQ("Language", "Russian")
                );

            var result = database.Find(query, database.Database.GetCollection("Books"));
           
            Assert.AreEqual(633, result.Count());
        }

        [Test]
        [ExpectedException]
        public void ReAddCategoryWillThrowExeption()
        {
            database.InsertCategory("Tex");
            database.InsertCategory("Tex");
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
                    new BookContainer
                        {
                            Authors = new List<string>(new[] {authors[random.Next(0, 19)], authors[random.Next(0, 19)]}),
                            ISBN = random.Next(100000000, 999999999).ToString(CultureInfo.InvariantCulture),
                            Title = nameBook[random.Next(0, 14)],
                            Language = language[index%2],
                            PageCount = random.Next(90, 500) + 100,
                            PublishHouse = "Цифровая книга",
                            Сategory = new List<string>(new[] {"Tex", "ABC"}),
                            PublishYear = random.Next(1900, 2015),
                        }.ToBsonDocument()
                    );
            }
       
            Trace.WriteLine(DateTime.Now - time);
        }
    }
}

