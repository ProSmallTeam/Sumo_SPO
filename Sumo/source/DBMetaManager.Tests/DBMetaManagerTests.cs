using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using DBMetaManager;
using Moq;
using NUnit.Framework;
using Sumo.Api;

namespace DBMetaManager.Tests
{
    [TestFixture]
    public class DBMetaManagerTests
    {
        [SetUp]
        public void SetUp()
        {
            var dbMock = new Mock<DB.IDataBase>();
            var metaManager = new DbMetaManager(dbMock.Object);

        }

        [Test]
        public void WillReturnOnlyDocumetsAtCorrectQuery ()
        {
            const string firstNotInterestingQuery = "not interesting query";
            const string secondNotInterestingQuery = "not interesting query";
            const string correctQuery = "Correct query";

            const int booksCount = 1;

            var someBook = new Book {Name = "some name"};
            var correctBook = new Book {Name = "correct book name"};


            var dbMock = new Mock<DB.IDataBase>();
            dbMock.Setup(m => m.GetStatistic(It.IsAny<string>())).Returns(booksCount);
            dbMock.Setup(m => m.GetBooks(It.Is<string>(str => str == firstNotInterestingQuery ||
                                                              str == secondNotInterestingQuery),
                It.IsAny<int>(),
                It.IsAny<int>()))
                .Returns(new List<Book> {someBook});
            dbMock.Setup(m => m.GetBooks(correctQuery,
                It.IsAny<int>(),
                It.IsAny<int>()))
                .Returns(new List<Book> {correctBook});


            var metaManager = new DbMetaManager(dbMock.Object);


            metaManager.CreateQuery(firstNotInterestingQuery);
            var session = metaManager.CreateQuery(correctQuery);
            metaManager.CreateQuery(secondNotInterestingQuery);

            var documents = metaManager.GetDocuments(session.SessionId, session.Count);

            Assert.AreEqual(booksCount, documents.Count);
            Assert.AreEqual(correctBook.Name, documents[0].Name);


            
        }
    }
}
