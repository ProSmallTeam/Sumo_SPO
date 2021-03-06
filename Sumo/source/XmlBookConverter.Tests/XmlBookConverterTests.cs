﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using NUnit.Framework;
using Sumo.Api;
using Sumo.Test.Utilities;

namespace XmlBookConverter.Tests
{
    [TestFixture]
    public class XmlBookConverterTests
    {
        private Dictionary<string, List<string>> _secondaryFields;

        [SetUp]
        public void SetUp()
        {
            _secondaryFields = new Dictionary<string, List<string>>
            {
                {"Authors", new List<string>(new[] {"4", "44", "444"})},
                {"Language", new List<string>(new[] {"5"})},
                {"ISBN", new List<string>(new[] {"6"})},
                {"PublicYear", new List<string>(new[] {"7"})}
            };
        }

        #region XmlToBookTests

        [Test]
        public void ParseIncorrectXmlTest()
        {
            var xmlContent = @"<AnyString></AnyString>";
            var xDocument = XDocument.Parse(xmlContent);

            var book = xDocument.ToBook();

            Assert.AreEqual("", book.Md5Hash);
            Assert.AreEqual("Пустой", book.Name);
            Assert.AreEqual("", book.Path);
            
            Assert.AreEqual(0, book.SecondaryFields.Count);
        }

        [Test]
        public void ParseFullXmlTest()
        {
            var xmlContent = @"<Book>	
    <Md5Hash>1</Md5Hash>
    <Name>2</Name>
	<Path>3</Path>
	<Authors>
        <Author>4</Author>
        <Author>44</Author>			
    </Authors>
	<PicturePath>5</PicturePath>	
	<FileFormat>6</FileFormat>	
	<InternalId>7</InternalId>
	<ISBN>8</ISBN>
	<Language>9</Language>
	<PublicHouse>10</PublicHouse>
	<PublicYear>11</PublicYear>
	<PageCount>12</PageCount>
	<Categories>13</Categories>
</Book>";
            var xDocument = XDocument.Parse(xmlContent);

            var book = xDocument.ToBook();

            Assert.AreEqual("1", book.Md5Hash);
            Assert.AreEqual("2", book.Name);
            Assert.AreEqual("3", book.Path);
            Assert.AreEqual("4", book.SecondaryFields["Authors"][0]);
            Assert.AreEqual("44", book.SecondaryFields["Authors"][1]);
            Assert.AreEqual("5", book.SecondaryFields["PicturePath"][0]);
            Assert.AreEqual("6", book.SecondaryFields["FileFormat"][0]);
            Assert.AreEqual("7", book.SecondaryFields["InternalId"][0]);
            Assert.AreEqual("8", book.SecondaryFields["ISBN"][0]);
            Assert.AreEqual("9", book.SecondaryFields["Language"][0]);
            Assert.AreEqual("10", book.SecondaryFields["PublicHouse"][0]);
            Assert.AreEqual("11", book.SecondaryFields["PublicYear"][0]);
            Assert.AreEqual("12", book.SecondaryFields["PageCount"][0]);
            Assert.AreEqual("13", book.SecondaryFields["Categories"][0]);

            Assert.AreEqual(10, book.SecondaryFields.Count);
        }

        [Test]
        public void ParseXmlWithoutNameTest()
        {
            const string xmlContent = @"<Book>	
    <Md5Hash>1</Md5Hash>
	<Path>3</Path>
	<Authors>
        <Author>4</Author>
        <Author>44</Author>			
    </Authors>
	<PicturePath>5</PicturePath>	
	<FileFormat>6</FileFormat>	
	<InternalId>7</InternalId>
	<ISBN>8</ISBN>
	<Language>9</Language>
	<PublicHouse>10</PublicHouse>
	<PublicYear>11</PublicYear>
	<PageCount>12</PageCount>
	<Categories>13</Categories>
</Book>";

            var xDocument = XDocument.Parse(xmlContent);

            var book = xDocument.ToBook();

            Assert.AreEqual("1", book.Md5Hash);
            Assert.AreEqual(string.Empty, book.Name);
            Assert.AreEqual("3", book.Path);
            Assert.AreEqual("4", book.SecondaryFields["Authors"][0]);
            Assert.AreEqual("44", book.SecondaryFields["Authors"][1]);
            Assert.AreEqual("5", book.SecondaryFields["PicturePath"][0]);
            Assert.AreEqual("6", book.SecondaryFields["FileFormat"][0]);
            Assert.AreEqual("7", book.SecondaryFields["InternalId"][0]);
            Assert.AreEqual("8", book.SecondaryFields["ISBN"][0]);
            Assert.AreEqual("9", book.SecondaryFields["Language"][0]);
            Assert.AreEqual("10", book.SecondaryFields["PublicHouse"][0]);
            Assert.AreEqual("11", book.SecondaryFields["PublicYear"][0]);
            Assert.AreEqual("12", book.SecondaryFields["PageCount"][0]);
            Assert.AreEqual("13", book.SecondaryFields["Categories"][0]);
        }

        [Test]
        public void ParseXmlWithoutMd5HashTest()
        {
            const string xmlContent = @"<Book>
    <Name>2</Name>
    <Path>3</Path>
	<Authors>
        <Author>4</Author>
        <Author>44</Author>			
    </Authors>
	<PicturePath>5</PicturePath>	
	<FileFormat>6</FileFormat>	
	<InternalId>7</InternalId>
	<ISBN>8</ISBN>
	<Language>9</Language>
	<PublicHouse>10</PublicHouse>
	<PublicYear>11</PublicYear>
	<PageCount>12</PageCount>
	<Categories>13</Categories>
</Book>";

            var xDocument = XDocument.Parse(xmlContent);

            var book = xDocument.ToBook();

            Assert.AreEqual(string.Empty, book.Md5Hash);
            Assert.AreEqual("2", book.Name);
            Assert.AreEqual("3", book.Path);
            Assert.AreEqual("4", book.SecondaryFields["Authors"][0]);
            Assert.AreEqual("44", book.SecondaryFields["Authors"][1]);
            Assert.AreEqual("5", book.SecondaryFields["PicturePath"][0]);
            Assert.AreEqual("6", book.SecondaryFields["FileFormat"][0]);
            Assert.AreEqual("7", book.SecondaryFields["InternalId"][0]);
            Assert.AreEqual("8", book.SecondaryFields["ISBN"][0]);
            Assert.AreEqual("9", book.SecondaryFields["Language"][0]);
            Assert.AreEqual("10", book.SecondaryFields["PublicHouse"][0]);
            Assert.AreEqual("11", book.SecondaryFields["PublicYear"][0]);
            Assert.AreEqual("12", book.SecondaryFields["PageCount"][0]);
            Assert.AreEqual("13", book.SecondaryFields["Categories"][0]);
        }

        [Test]
        public void ParseXmlWithoutSecondaryFieldsTest()
        {
            var xmlContent = @"<Book>
    <Md5Hash>1</Md5Hash>
    <Name>2</Name>
	<Path>3</Path>
</Book>";

            var xDocument = XDocument.Parse(xmlContent);

            var book = xDocument.ToBook();

            Assert.AreEqual("1", book.Md5Hash);
            Assert.AreEqual("2", book.Name);
            Assert.AreEqual("3", book.Path);
            Assert.AreEqual(0, book.SecondaryFields.Count);
        }

        #endregion

        #region BookToXmlTests

        [Test]
        public void FullBookToXmlTest()
        {
            var book = new Book
            {
                Md5Hash = "1",
                Name = "2",
                Path = "3",
                SecondaryFields = _secondaryFields
            };

            var xDocument = BookConverter.ToXml(book);


            Trace.WriteLine(xDocument.ToString());

            CompareIgnoreWhiteSpaces(
                @"<Book>
                  <Md5Hash>1</Md5Hash>
                  <Name>2</Name>
                  <Path>3</Path>
                  <Authors>
                    <Item1>4</Item1>
                    <Item2>44</Item2>
                    <Item3>444</Item3>
                  </Authors>
                  <Language>5</Language>
                  <ISBN>6</ISBN>
                  <PublicYear>7</PublicYear>
                </Book>", xDocument);
        }

        [Test]
        public void BookWithoutNameToXmlTest()
        {
            var book = new Book
            {
                Md5Hash = "1",
                Name = null,
                Path = "3",
                SecondaryFields = _secondaryFields
            };

            var xDocument = BookConverter.ToXml(book);

            Trace.WriteLine(xDocument);

            CompareIgnoreWhiteSpaces(
                @"<Book>
                  <Md5Hash>1</Md5Hash>
                  <Path>3</Path>
                  <Authors>
                    <Item1>4</Item1>
                    <Item2>44</Item2>
                    <Item3>444</Item3>
                  </Authors>
                  <Language>5</Language>
                  <ISBN>6</ISBN>
                  <PublicYear>7</PublicYear>
                </Book>", xDocument);
        }

        [Test]
        public void BookWithoutMd5HashToXmlTest()
        {
            var book = new Book
            {
                Md5Hash = null,
                Name = "2",
                Path = "3",
                SecondaryFields = _secondaryFields
            };

            var xDocument = BookConverter.ToXml(book);

            CompareIgnoreWhiteSpaces(
                @"<Book>
                  <Name>2</Name>
                  <Path>3</Path>
                  <Authors>
                    <Item1>4</Item1>
                    <Item2>44</Item2>
                    <Item3>444</Item3>
                  </Authors>
                  <Language>5</Language>
                  <ISBN>6</ISBN>
                  <PublicYear>7</PublicYear>
                </Book>", xDocument);
        }

        [Test]
        public void BookWithoutSecondaryFieldsToXmlTest()
        {
            var book = new Book
            {
                Md5Hash = "1",
                Name = "2",
                Path = "3",
                SecondaryFields = null
            };

            var xDocument = BookConverter.ToXml(book);

            Trace.WriteLine(xDocument);

            CompareIgnoreWhiteSpaces(
                @"<Book>
                  <Md5Hash>1</Md5Hash>
                  <Name>2</Name>
                  <Path>3</Path>
                </Book>", xDocument);
        }

        #endregion

        [Test]
        public void BookToXmlToBookTest()
        {
            var book = new Book
            {
                Md5Hash = "1",
                Name = "2",
                Path = "3",
                SecondaryFields = _secondaryFields
            };

            var xDocument = book.ToXml();

            var book2 = xDocument.ToBook();

            Assert.AreEqual(book.Md5Hash, book2.Md5Hash);
            Assert.AreEqual(book.Name, book2.Name);
            Assert.AreEqual(book.Path, book2.Path);
            Assert.AreEqual(book.SecondaryFields.Count, book2.SecondaryFields.Count);
            Assert.AreEqual(book.SecondaryFields.Keys, book2.SecondaryFields.Keys);
            Assert.AreEqual(book.SecondaryFields.Values, book2.SecondaryFields.Values);
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
