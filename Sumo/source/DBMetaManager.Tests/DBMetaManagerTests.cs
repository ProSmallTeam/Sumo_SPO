using System.Collections.Generic;
using DB;
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
        }

        [Test]
        public void WillReturnCorectStatisticOnGetStatistic()
        {
            const string someQuery = "some query";

            var dbMock = new Mock<IDataBase>();

            var metaManager = new DbMetaManager(dbMock.Object);

            metaManager.CreateQuery(someQuery);
            var session = metaManager.CreateQuery(someQuery);
            metaManager.CreateQuery(someQuery);

            metaManager.GetStatistic(session.SessionId);

            dbMock.Verify(db => db.GetStatistic(someQuery), Times.AtLeastOnce);
            dbMock.Verify(db =>
                db.GetStatistic(It.IsNotIn(new string[] { someQuery })), Times.Never);

        }

        [Test]
        public void GetStasticWithNotExistingSessionWillReturnEmptyStatistic()
        {
            var dataBase = Mock.Of<IDataBase>();

            var metaManager = new DbMetaManager(dataBase);

            var session = metaManager.CreateQuery("query");
            metaManager.CloseSession(new SumoSession());

            var statistic = metaManager.GetStatistic(session.SessionId);

            Assert.AreEqual(0, statistic.Node.Count);
            Assert.AreEqual(0, statistic.Childs.Count);
        }


        [Test]
        public void GetDocumentsWithNotExistingSessionWillReturnEmptyCollection()
        {
            var dataBase = Mock.Of<IDataBase>();

            var metaManager = new DbMetaManager(dataBase);

            var session = metaManager.CreateQuery("query");
            metaManager.CloseSession(new SumoSession());

            var documents = metaManager.GetDocuments(session.SessionId, session.Count);

            Assert.AreEqual(0, documents.Count);
        }

        [Test]
        public void ClosingNotExistingSessionWillNotThrowException()
        {
            var dataBase = Mock.Of<IDataBase>();

            var metaManager = new DbMetaManager(dataBase);

            metaManager.CloseSession(new SumoSession());
        }

        [Test]
        public void WillReturnCorrectSessionOnCreatingNewSession()
        {
            const int expectedCountOfBooks = 10;
            const string query = "some string";

            var dataBase = Mock.Of<IDataBase>(db =>
                db.GetStatistic(It.IsAny<string>()) == expectedCountOfBooks);

            var mock = Mock.Get(dataBase);

            var metaManager = new DbMetaManager(dataBase);

            var session = metaManager.CreateQuery(query);

            mock.Verify(d => d.GetStatistic(query), Times.Once);
            
            Assert.AreEqual(expectedCountOfBooks, session.Count);


        }

        [Test]
        public void WillReturnOnlyDocumetsAtCorrectQuery ()
        {
            var notInterestingQueries = new[] { "firstNotInterestingQuery", "secondNotInterestingQuery" };
            const string correctQuery = "Correct query";
            

            const int booksCount = 1;

            var someBook = new Book {Name = "some name"};
            var correctBook = new Book {Name = "correct book name"};

            var dbMock = Mock.Of<IDataBase>( db =>
                db.GetStatistic(It.IsAny<string>()) == booksCount &&
                db.GetBooks(It.IsIn(notInterestingQueries), It.IsAny<int>(), It.IsAny<int>()) == new List<Book> {someBook} &&
                db.GetBooks(correctQuery, It.IsAny<int>(), It.IsAny<int>()) == new List<Book> { correctBook }
                );

            var metaManager = new DbMetaManager(dbMock);


            metaManager.CreateQuery(notInterestingQueries[0]);
            var session = metaManager.CreateQuery(correctQuery);
            metaManager.CreateQuery(notInterestingQueries[1]);

            var documents = metaManager.GetDocuments(session.SessionId, session.Count);

            Assert.AreEqual(booksCount, documents.Count);
            Assert.AreEqual(correctBook.Name, documents[0].Name);


            
        }
    }
}
