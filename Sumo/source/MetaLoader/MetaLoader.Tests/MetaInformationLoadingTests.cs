using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Moq;
using Sumo.Api.Network;
using Sumo.Test.Utilities;
using XmlBookConverter;

namespace MetaLoaderLib.Tests
{
    using System.IO;
    using System.Text;
    using OzonShop;
    using HtmlAgilityPack;
    using NUnit.Framework;

    /// <summary>
    /// The meta information loading tests.
    /// </summary>
    [TestFixture]
    public class MetaInformationLoadingTests
    {
        private Mock<INetwork> _networkMock;
        private OzonBookShop _shop;

        [SetUp]
        public void SetUp()
        {
            _networkMock = new Mock<INetwork>();

            _shop = new OzonBookShop(_networkMock.Object);
        }

        [Test]
        public void OzonShopSingleResultTest()
        {
            foreach (var directory in Directory.GetDirectories(".\\htmFiles\\Single"))
            {
                var sampleBody = new StreamReader(directory + "\\Sample.htm", Encoding.Default).ReadToEnd();

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(sampleBody);

                var page = new Page
                    {
                        Document = htmlDocument,
                        Url = directory + "\\Sample.htm"
                    };

                var resultBooks = _shop.Parse(page).ToList();
                Assert.IsTrue(resultBooks.Any());

                var book = resultBooks.First();

                var exceptedBookXml = File.ReadAllText(directory + "\\result.xml");

                CompareIgnoreWhiteSpaces(exceptedBookXml, book.ToXml());
            }
        }
        
        [Test]
        public void OzonShopMultiResultsTest()
        {
            int c = 0;
            foreach (var directory in Directory.GetDirectories(".\\htmFiles\\Multi"))
            {
                _networkMock.Setup(n => n.LoadDocument(It.IsAny<string>())).Returns(new Page("", new HtmlDocument()));

                var sampleBody = new StreamReader(directory + "\\Sample.htm", Encoding.Default).ReadToEnd();

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(sampleBody);

                _shop.ParseMultiPage(htmlDocument);

                Trace.WriteLine(directory + "\\result.xml");

                var urls = XDocument.Load(directory + "\\result.xml").
                    Element("Urls").Elements("Url").Select(n => n.Value).ToList();

                foreach (string url in urls)
                    _networkMock.Verify(n => n.LoadDocument(url), Times.Once);    
            }
        }

        /// <summary>
        /// Производит сравнение xml с xDocument без учета символов переноса строк.
        /// </summary>
        private void CompareIgnoreWhiteSpaces(string xml, XDocument xDocument)
        {
            var xmlWithoutFormatting = xml.RemoveWhiteSpaces();
            Assert.AreEqual(xmlWithoutFormatting, xDocument.ToString(SaveOptions.DisableFormatting));
        }

    }
}