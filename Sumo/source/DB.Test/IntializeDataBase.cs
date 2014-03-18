using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using Sumo.API;
using NUnit.Framework;

namespace DB.Test
{
    public static class IntializeDataBase
    {
        public static void Initialize(DataBase dataBase, int NumberOfRecords)
        {
            dataBase.Drop();

            InitializeAttr(dataBase);
            InitializeDb(dataBase, NumberOfRecords);
            dataBase.Indexing();
        }

        private static void InitializeAttr(DataBase dataBase)
        {
            var authors = new[]
                {
                    "Макарский", "М. Ховард", "Леви", "Вэймир", "Шмерлинг", "Уилкинс", "Жарков",
                    "Маклин", "Томас",
                    "Гудсон", "Харвелл", "Уайт", "Пастернак", "Виннер",
                    "Фриман", "Уэнц",
                    "Мак-Дональд", "Колисниченко", "Грачев"
                };

            dataBase.Database.GetCollection("Attributes").Insert(new BsonDocument { { "_id", 1 }, { "Name", "Authors" }, { "RootRef", 0 }, { "FatherRef", 0 } });
            dataBase.Database.GetCollection("Attributes").Insert(new BsonDocument { { "_id", 2 }, { "Name", "Year" }, { "RootRef", 0 }, { "FatherRef", 0 } });

            foreach (var temp in authors)
                dataBase.Database.GetCollection("Attributes").Insert(new BsonDocument
                    {
                        {"_id", dataBase.Database.GetCollection("Attributes").Count() + 1},
                        {"Name", temp},
                        {"RootRef", 1},
                        {"FatherRef", 1}
                    }
                    );

            for (var index = 1950; index < 2011; ++index)
                dataBase.Database.GetCollection("Attributes").Insert(new BsonDocument
                    {
                        {"_id", dataBase.Database.GetCollection("Attributes").Count() + 1},
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
                                  "Макарский", "М. Ховард", "Леви", "Вэймир", "Шмерлинг", "Уилкинс", "Жарков",
                                     "Маклин", "Томас",
                                        "Гудсон", "Харвелл", "Уайт", "Пастернак", "Виннер",
                                             "Фриман", "Уэнц",
                                                 "Мак-Дональд", "Колисниченко", "Грачев"
                              };
            var arrayOfPriority = new[] { true, false };

            for (var index = 0; index < numberOfRecords; ++index)
            {
                var listOfAltBook = new List<Book>();
                for (var indexes = 0; indexes < 5; ++indexes)
                {
                    listOfAltBook.Add(
                        new Book
                        {
                            Name = nameBook[index % nameBook.Count()],
                            Md5Hash = indexes.ToString(),
                            Path = null,
                            SecondaryFields = new Dictionary<string, List<string>>
                                        {
                                            {"Year", new List<string>{(2010 - index % 50).ToString()}},
                                            {"Author", new List<string>{authors[index % authors.Count()]}}
                                        }
                        }
                            );
                }

                dataBase.SaveBookMeta(
                    new Book()
                        {
                            Name = nameBook[index%nameBook.Count()],
                            Md5Hash = index.ToString(),
                            Path = null,
                            SecondaryFields = new Dictionary<string, List<string>>
                                {
                                    {"Year", new List<string>{(2010 - index % 50).ToString()}},
                                    {"Author", new List<string>{authors[index % authors.Count()], authors[(index + 1) % authors.Count()]}}
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
        }

        }
    
}