using OzonShop;

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
    }
}