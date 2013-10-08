namespace InitializeDataBase
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    class Program
    {
        static void Main()
        {
            var database = new DataBase("mongodb://localhost/?safe=true"); // получение объекта, с которым будем работать

            var collection = database.GetCollection("Books"); // получение ссылки на колекцию, то есть создание новой

            database.Drop();

            var random = new Random();

            var nameBook = new[]
                               {
                                   "C", "C++", "C#", "Java", "PHP", "JavaScript", 
                                   "Assembler", "AutoCAD Civil 3D 2013. Официальный учебный курс", 
                                   "25 этюдов о шифрах", "Яндекс Воложа. История создания компании мечты",
                                   "Изучаем HTML, XHTML", " Самоучитель работы на ПК для всех",
                                   "Журнал CHIP, сентябрь №9/2013", "Интернет-программирование на Java", "Компьютер для женщин"
                               };

            var authors = new[]
                              {
                                  "Дмитрий Макарский", "М. Ховард", " М. Леви", "Р. Вэймир", "Г. Шмерлинг",
                                  "Трев Уилкинс", "В. А. Жарков", "Йен Маклин", "Орин Томас", "Джон Гудсон",
                                  "Бен Харвелл", "Бен Харвелл", "Том Уайт", "Евгения Пастернак", "Марина Виннер",
                                  "Майкл Фриман", "Кристиан Уэнц", "Мэтью Мак-Дональд", "Д. Н. Колисниченко", "Андрей Грачев"
                              };

            var language = new[] { "Russian", "English" };

            var time = DateTime.Now;

            for (var index = 0; index < 100; ++index)
            {
                collection.Insert(
                    new Book
                    {
                        _id = random.Next(0, 9).ToString() +
                        random.Next(0, 9).ToString() +
                        random.Next(0, 9).ToString() +
                        random.Next(0, 9).ToString() +
                        random.Next(0, 9).ToString() +
                        random.Next(0, 9).ToString(),
                        BookInformation =
                            new BookInformation
                            {
                                Name = nameBook[random.Next(0, 14)],
                                CountOfPages = random.Next(90, 500) + 100,
                                ISBN = random.Next(100000000, 999999999).ToString(CultureInfo.InvariantCulture),
                                YearOfPublication = random.Next(1900, 2014),
                                Authors = new List<string>(new[]
                                            {
                                                authors[random.Next(0, 19)], 
                                                authors[random.Next(0, 19)]
                                            }),
                                Language = language[index % 2],
                                Edition = "Цифровая книга"
                            },
                        Attribute = new Attribute
                        {
                            ReferenceToTheBook = @"C:\Users\Documents\GitHub\Sumo_SPO\" + random.Next(0, 14) + ".pdf",
                            fileExtension = "pdf",
                            Categories = new List<string>(new[] { "Tex" })
                        }
                    });
            }
            Console.WriteLine(DateTime.Now - time);
        }
    }
}
