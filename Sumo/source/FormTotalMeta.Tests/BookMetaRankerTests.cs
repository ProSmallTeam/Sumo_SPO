using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using FormTotalMeta;
using NUnit.Framework;
using Sumo.Test.Utilities;
using XmlBookConverter;

namespace FormTotalMeta.Tests
{
    [TestFixture]
    public class BookMetaRankerTests
    {
        [Test]
        public void FirstRankMetaTest()
        {
            var meta = ReadMetaFrom(@"xmlfiles\Игра престолов. Битва королей");

            var rankedMetaList = BookMetaRanker.RankMeta(meta).Select(t => BookConverter.ToXml(t)).ToList();

            Assert.AreEqual(File.ReadAllText(@"xmlfiles\Игра престолов. Битва королей\Ozon.xml").RemoveWhiteSpaces(),
                ToXmlDocument(rankedMetaList[0]).OuterXml.RemoveWhiteSpaces());
            Assert.AreEqual(File.ReadAllText(@"xmlfiles\Игра престолов. Битва королей\Labirint.xml").RemoveWhiteSpaces(),
                ToXmlDocument(rankedMetaList[1]).OuterXml.RemoveWhiteSpaces());
            Assert.AreEqual(File.ReadAllText(@"xmlfiles\Игра престолов. Битва королей\Москва.xml").RemoveWhiteSpaces(),
                ToXmlDocument(rankedMetaList[2]).OuterXml.RemoveWhiteSpaces());
        }

        [Test]
        public void SecondRankMetaTest()
        {
            var meta = ReadMetaFrom(@"xmlfiles\Океан в конце дороги");

            var rankedMetaList = BookMetaRanker.RankMeta(meta).Select(t => BookConverter.ToXml(t)).ToList();

            Assert.AreEqual(File.ReadAllText(@"xmlfiles\Океан в конце дороги\Labirint.xml").RemoveWhiteSpaces(),
                ToXmlDocument(rankedMetaList[0]).OuterXml.RemoveWhiteSpaces());
            Assert.AreEqual(File.ReadAllText(@"xmlfiles\Океан в конце дороги\Ozon.xml").RemoveWhiteSpaces(),
                ToXmlDocument(rankedMetaList[1]).OuterXml.RemoveWhiteSpaces());
            Assert.AreEqual(File.ReadAllText(@"xmlfiles\Океан в конце дороги\Новый книжный.xml").RemoveWhiteSpaces(),
                ToXmlDocument(rankedMetaList[2]).OuterXml.RemoveWhiteSpaces());
        }

        [Test]
        public void ThirdRankMetaTest()
        {
            var meta = ReadMetaFrom(@"xmlfiles\Рыцарь Семи Королевств");

            var rankedMetaList = BookMetaRanker.RankMeta(meta).Select(t => BookConverter.ToXml(t)).ToList();

            Assert.AreEqual(File.ReadAllText(@"xmlfiles\Рыцарь Семи Королевств\Читай город.xml").RemoveWhiteSpaces(),
                ToXmlDocument(rankedMetaList[0]).OuterXml.RemoveWhiteSpaces());
            Assert.AreEqual(File.ReadAllText(@"xmlfiles\Рыцарь Семи Королевств\Москва.xml").RemoveWhiteSpaces(),
                ToXmlDocument(rankedMetaList[1]).OuterXml.RemoveWhiteSpaces());
            Assert.AreEqual(File.ReadAllText(@"xmlfiles\Рыцарь Семи Королевств\Labirint.xml").RemoveWhiteSpaces(),
                ToXmlDocument(rankedMetaList[2]).OuterXml.RemoveWhiteSpaces());
        }

        private static OriginalMetaInformation ReadMetaFrom(string directoryName)
        {
            var primaryMetaFileName = Path.Combine(directoryName, "primary.xml");

            var primaryMeta = XDocument.Load(primaryMetaFileName);

            var pathToFiles = Directory.GetFiles(directoryName, "*.xml").Where(p => p != primaryMetaFileName);

            var alternativeMeta = pathToFiles.Select(XDocument.Load).ToList();

            return new OriginalMetaInformation(primaryMeta, alternativeMeta);
        }

        private XmlDocument ToXmlDocument(XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        private string XDocToString(XDocument xDocument)
        {
            var builder = new StringBuilder();
            using (TextWriter writer = new StringWriter(builder))
            {
                xDocument.Save(writer);
            }

            return builder.ToString();
        }
    }
}
