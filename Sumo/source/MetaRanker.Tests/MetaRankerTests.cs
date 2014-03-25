namespace MetaRanker.Tests
{
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using NUnit.Framework;
    using Sumo.Utilities;

    [TestFixture]
    public class MetaRankerTests
    {
        [Test]
        public void BuildTotalMeta(
            [Values(@"xmlfiles\Игра престолов. Битва королей",
                    @"xmlfiles\Океан в конце дороги",
                    @"xmlfiles\Рыцарь Семи Королевств")] string directoryName)
        {
            var meta = ReadMetaFrom(directoryName);

            var totalMeta = MetaRanker.GetTotalMetaFor(meta).ToString().RemoveWhiteSpaces();

            var expectedTotalMeta = ReadTotalFileContent(directoryName);

            Assert.AreEqual(expectedTotalMeta, totalMeta);
        }

        #region Private Methods

        private static OriginalMetaInformation ReadMetaFrom(string directoryName)
        {
            var primaryMetaFileName = Path.Combine(directoryName, "primary.xml");

            var primaryMeta = XDocument.Load(primaryMetaFileName);

            var pathToFiles = Directory.GetFiles(directoryName, "*.xml").Where(p => p != primaryMetaFileName);

            var alternativeMeta = pathToFiles.Select(XDocument.Load).ToList();

            return new OriginalMetaInformation(primaryMeta, alternativeMeta);
        }

        private static string ReadTotalFileContent(string directoryName)
        {
            var totalFileName = Path.Combine(directoryName, "total.meta");

            return File.ReadAllText(totalFileName).RemoveWhiteSpaces();
        }

        #endregion
    }
}
