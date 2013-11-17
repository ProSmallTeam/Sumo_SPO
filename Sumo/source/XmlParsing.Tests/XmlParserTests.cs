using NUnit.Framework;

namespace XmlParsing.Tests
{
    public class XmlParserTests
    {
        [Test]
        public void TestWithFullXml()
        {
            var xml = @"<Book>	
    <Md5Hash>1</Md5Hash>
    <Name>2</Name>
	<Path>3</Path>
	<SecondaryFields>
		<Authors>4</Authors>
		<PicturePath>5</PicturePath>	
		<FileFormat>6</FileFormat>	
		<InternalId>7</InternalId>
		<ISBN>8</ISBN>
		<Language>9</Language>
		<PublicHouse>10</PublicHouse>
		<PublicYear>11</PublicYear>
		<PageCount>12</PageCount>
		<Categories>13</Categories>
	</SecondaryFields>
</Book>";

            var book = XmlParser.Parse(xml);

            Assert.AreEqual("1", book.Md5Hash);
            Assert.AreEqual("2", book.Name);
            Assert.AreEqual("3", book.Path);
            Assert.AreEqual("4", book.SecondaryFields["Authors"]);
            Assert.AreEqual("5", book.SecondaryFields["PicturePath"]);
            Assert.AreEqual("6", book.SecondaryFields["FileFormat"]);
            Assert.AreEqual("7", book.SecondaryFields["InternalId"]);
            Assert.AreEqual("8", book.SecondaryFields["ISBN"]);
            Assert.AreEqual("9", book.SecondaryFields["Language"]);
            Assert.AreEqual("10", book.SecondaryFields["PublicHouse"]);
            Assert.AreEqual("11", book.SecondaryFields["PublicYear"]);
            Assert.AreEqual("12", book.SecondaryFields["PageCount"]);
            Assert.AreEqual("13", book.SecondaryFields["Categories"]);
        }

        [Test]
        public void TestXmlWithoutName()
        {
            var xml = @"<Book>	
    <Md5Hash>1</Md5Hash>
	<Path>3</Path>
	<SecondaryFields>
		<Authors>4</Authors>
		<PicturePath>5</PicturePath>	
		<FileFormat>6</FileFormat>	
		<InternalId>7</InternalId>
		<ISBN>8</ISBN>
		<Language>9</Language>
		<PublicHouse>10</PublicHouse>
		<PublicYear>11</PublicYear>
		<PageCount>12</PageCount>
		<Categories>13</Categories>
	</SecondaryFields>
</Book>";

            var book = XmlParser.Parse(xml);

            Assert.AreEqual("1", book.Md5Hash);
            Assert.IsNull(book.Name);
            Assert.AreEqual("3", book.Path);
            Assert.AreEqual("4", book.SecondaryFields["Authors"]);
            Assert.AreEqual("5", book.SecondaryFields["PicturePath"]);
            Assert.AreEqual("6", book.SecondaryFields["FileFormat"]);
            Assert.AreEqual("7", book.SecondaryFields["InternalId"]);
            Assert.AreEqual("8", book.SecondaryFields["ISBN"]);
            Assert.AreEqual("9", book.SecondaryFields["Language"]);
            Assert.AreEqual("10", book.SecondaryFields["PublicHouse"]);
            Assert.AreEqual("11", book.SecondaryFields["PublicYear"]);
            Assert.AreEqual("12", book.SecondaryFields["PageCount"]);
            Assert.AreEqual("13", book.SecondaryFields["Categories"]);
        }

        [Test]
        public void TestXmlWithoutMd5Hash()
        {
            var xml = @"<Book>
    <Name>2</Name>
	<Path>3</Path>
	<SecondaryFields>
		<Authors>4</Authors>
		<PicturePath>5</PicturePath>	
		<FileFormat>6</FileFormat>	
		<InternalId>7</InternalId>
		<ISBN>8</ISBN>
		<Language>9</Language>
		<PublicHouse>10</PublicHouse>
		<PublicYear>11</PublicYear>
		<PageCount>12</PageCount>
		<Categories>13</Categories>
	</SecondaryFields>
</Book>";

            var book = XmlParser.Parse(xml);

            Assert.IsNull(book.Md5Hash);
            Assert.AreEqual("2", book.Name);
            Assert.AreEqual("3", book.Path);
            Assert.AreEqual("4", book.SecondaryFields["Authors"]);
            Assert.AreEqual("5", book.SecondaryFields["PicturePath"]);
            Assert.AreEqual("6", book.SecondaryFields["FileFormat"]);
            Assert.AreEqual("7", book.SecondaryFields["InternalId"]);
            Assert.AreEqual("8", book.SecondaryFields["ISBN"]);
            Assert.AreEqual("9", book.SecondaryFields["Language"]);
            Assert.AreEqual("10", book.SecondaryFields["PublicHouse"]);
            Assert.AreEqual("11", book.SecondaryFields["PublicYear"]);
            Assert.AreEqual("12", book.SecondaryFields["PageCount"]);
            Assert.AreEqual("13", book.SecondaryFields["Categories"]);
        }

        [Test]
        public void TestXmlWithoutSecondaryFields()
        {
            var xml = @"<Book>
    <Name>2</Name>
	<Path>3</Path>
</Book>";

            var book = XmlParser.Parse(xml);

            Assert.AreEqual("2", book.Name);
            Assert.AreEqual("3", book.Path);
            Assert.AreEqual(0, book.SecondaryFields.Count);
        }
    }
}
