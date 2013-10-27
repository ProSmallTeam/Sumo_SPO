namespace Sumo_MetaInformationLoading.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Sumo_MetaInformationLoading.Ozon;

    [TestFixture]
    public class MetaInformationLoadingTests
    {
        public const string ValidIsbn = "978-5-7502-0413-7";
        public const string InvalidIsbn = "Some crap";

        [Test]
        public void ValidIsbnTest()
        {
            var goodContainer = OzonPageParser.Parse(ValidIsbn);
            Assert.AreEqual(goodContainer.Author, "Питер Гастон");
            Assert.AreEqual(goodContainer.PageCount, 272);
            Assert.AreEqual(goodContainer.PublishYear, "2012");
            Assert.AreEqual(goodContainer.InternalId, "8465610");
            Assert.AreEqual(goodContainer.Languages, "Русский");
            Assert.AreEqual(goodContainer.PublishHouse, "БХВ-Петербург");
            Assert.AreEqual(goodContainer.RuTitle, "CSS3. Руководство разработчика");
            Assert.AreEqual(goodContainer.Link, "http://www.ozon.ru/context/detail/id/8465610/");
            Assert.AreEqual(goodContainer.ISBN, new List<string>
                                                            {
                                                                "978-5-7502-0413-7",
                                                                "978-5-9775-0845-2"
                                                            });
            Assert.AreEqual(goodContainer.Сategories.Chain, new List<string>
                                                            {
                                                                "Книги",
                                                                "Нехудожественная литература",
                                                                "Компьютерная литература",
                                                                "Интернет и Web-страницы",
                                                                "Web-мастеринг. Языки и инструменты",
                                                                "ASP, Perl, CGI, Python и другие языки для разработки Web-сайтов",
                                                                "CSS3. Руководство разработчика"
                                                            });

        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void InvalidIsbnTest()
        {
            var badContainer = OzonPageParser.Parse(InvalidIsbn);
        }
    }
}