using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OzonShop;
using Sumo.Api;
using XmlBookConverter;
using XmlBookConverter.Tests;

namespace MetaLoaderLib.Tests
{
    using HtmlAgilityPack;

    using Network;

    using NUnit.Framework;

    /// <summary>
    /// The meta information loading tests.
    /// </summary>
    [TestFixture]
    public class MetaInformationLoadingTests
    {
        private List<string> _documentForTestingPaths;
        private readonly HttpNetwork _network = new HttpNetwork();
        private OzonBookShop _shop;

        [SetUp]
        public void TestsSetup()
        {
            _shop = new OzonBookShop(_network);

            _documentForTestingPaths = new List<string>();

            var documentsPath = Directory.GetDirectories(".\\htmFiles");

            _documentForTestingPaths.AddRange(documentsPath);
        }

        [Test]
        public void OzonShopTest()
        {
            var htmlDocument = new HtmlDocument();

            foreach (var documentPath in _documentForTestingPaths)
            {
                var sampleBody = new StreamReader(documentPath + "\\Sample.htm", Encoding.Default).ReadToEnd();
                htmlDocument.LoadHtml(sampleBody);

                var page = new Page()
                {
                    Document = htmlDocument,
                    Url = documentPath + "\\Sample.html"
                };

                var resultBooks = _shop.Parse(page);

                //var result = resultBooks.Aggregate<Book, string>(null, (current, book) => current + book..ToString());

                var exceptedXml = File.ReadAllText(documentPath + "\\result.xml");

                //Assert.AreEqual(exceptedXml, result);
            }
        }
        /*
                /// <summary>
                /// The ozon test.
                /// </summary>
                [Test]
                public void OzonShopTest()
                {
                    var htmlDocument = new HtmlDocument();
                    htmlDocument.Load("SampleOzon.htm");

                    var page = new Page { Url = "SampleOzon.htm", Document = htmlDocument };

                    var network = new HttpNetwork();
                    var shop = new OzonBookShop(network);

                    var book = shop.Parse(page);
                }
                public const string ValidIsbn = "978-5-7502-0413-7";
                public const string InvalidIsbn = "Some crap";

        /*        [Test]
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
                }*/
    }
}