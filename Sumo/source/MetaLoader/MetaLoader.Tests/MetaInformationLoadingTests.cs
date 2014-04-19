using OzonShop;

namespace MetaLoaderLib.Tests
{
    using System.Collections.Generic;

    using HtmlAgilityPack;

    using Network;

    using NUnit.Framework;

    /// <summary>
    /// The meta information loading tests.
    /// </summary>
    [TestFixture]

    public class MetaInformationLoadingTests
    {
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

            var book = shop.Parse(page)[0];

            Assert.AreEqual("CSS3. Руководство разработчика", book.Name);
            Assert.AreEqual(
            new List<string>
            {
                "978-5-7502-0413-7",
                "978-5-9775-0845-2"
            },
                book.SecondaryFields["ISBN"]);
            Assert.AreEqual(new List<string> { "БХВ-Петербург" }, book.SecondaryFields["PublishHouse"]);
            Assert.AreEqual(new List<string> { "Русский" }, book.SecondaryFields["Language"]);
            Assert.AreEqual(new List<string> { "Питер Гастон" }, book.SecondaryFields["Author"]);
            Assert.AreEqual(new List<string> { "8465610" }, book.SecondaryFields["InternalId"]);
            Assert.AreEqual(new List<string> { "SampleOzon.htm" }, book.SecondaryFields["UrlLink"]);
            Assert.AreEqual(new List<string> { "2012" }, book.SecondaryFields["PublishYear"]);
            Assert.AreEqual(new List<string> { "272" }, book.SecondaryFields["PageCount"]);
            Assert.AreEqual(new List<string> { "./Sample_files/1005192119(1).jpg" }, book.SecondaryFields["PictureLink"]);
        }
    }
}