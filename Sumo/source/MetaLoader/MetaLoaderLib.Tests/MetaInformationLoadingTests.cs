namespace MetaLoaderLib.Tests
{
    using System.Collections.Generic;

    using HtmlAgilityPack;

    using MetaLoaderLib.Labirint;
    using MetaLoaderLib.Ozon;

    using NUnit.Framework;

    [TestFixture]
    public class MetaInformationLoadingTests
    {
        [Test]
        public void OzonTest()
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load("Sample.htm");
            var parser = new OzonPageParser(htmlDocument, "http://www.ozon.ru/context/detail/id/8465610/");
            var goodContainer = parser.Parse();
            Assert.AreEqual(goodContainer.Author, "Питер Гастон");
            Assert.AreEqual(goodContainer.PageCount, 272);
            Assert.AreEqual(goodContainer.PublishYear, "2012");
            Assert.AreEqual(goodContainer.InternalId, "8465610");
            Assert.AreEqual(goodContainer.Language, "Русский");
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
        public void LabirintTest()
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load("Labirint.htm");
            var parser = new LabirintPageParser(htmlDocument, "http://www.labirint.ru/books/407352/");
            var goodContainer = parser.Parse();
            Assert.AreEqual(goodContainer.Author, "Бен Фрейн");
            Assert.AreEqual(goodContainer.PageCount, 304);
            Assert.AreEqual(goodContainer.PublishYear, "2014");
            Assert.AreEqual(goodContainer.InternalId, "407352");
            //Assert.AreEqual(goodContainer.Language, "Русский"); не всегда есть язык
            Assert.AreEqual(goodContainer.PublishHouse, "Питер");
            Assert.AreEqual(goodContainer.RuTitle, "HTML5 и CSS3.Разработка сайтов для любых браузеров и устройств");
            Assert.AreEqual(goodContainer.Link, "http://www.labirint.ru/books/407352/");
            /* Assert.AreEqual(goodContainer.ISBN, new List<string>
                                                            {
                                                                "978-5-496-00185-4",
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
                                                            });*/

        }
    }
}
