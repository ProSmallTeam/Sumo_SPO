using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Sumo.Api;

namespace DBTaskManager.Tests
{
    [TestFixture]
    public class DBTaskManagerTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void WillReturnCorectTasksOnGetTasks()
        {
            string[] tasks = {"task1", "task2"};
            const int someMaxCount = 5;
            

            var dbMock = new Mock<ITaskManagerDBProvider>();
            dbMock.Setup(m => m.GetTask(It.IsAny<int>())).Returns(tasks.Select(t => new Task{PathToFile = t}).ToList());


            var dbTaskManager = new DbTaskManager(dbMock.Object);

            var returnedTasks = dbTaskManager.GetTasks(someMaxCount);

            CollectionAssert.AreEquivalent(tasks, returnedTasks);
            dbMock.Verify(db => db.GetTask(someMaxCount), Times.Once);

        }

        [Test]
        public void WillReturnNoTasksWhenNoTasksExistOnGetTasks()
        {
            const int someMaxCount = 5;


            var dbMock = new Mock<ITaskManagerDBProvider>();
            dbMock.Setup(m => m.GetTask(It.IsAny<int>())).Returns(new List<Task>(0));


            var dbTaskManager = new DbTaskManager(dbMock.Object);

            var returnedTasks = dbTaskManager.GetTasks(someMaxCount);

            Assert.AreEqual(returnedTasks.Length, 0);
            dbMock.Verify(db => db.GetTask(someMaxCount), Times.Once);
        }

        [Test]
        public void WillReturnNoTasksWhenMaxCountEqualsToZeroOnGetTasks()
        {

            string[] tasks = { "task1", "task2" };
            const int zeroMaxCount = 0;

            var dbMock = new Mock<ITaskManagerDBProvider>();
            dbMock.Setup(m => m.GetTask(It.IsAny<int>())).Returns(tasks.Select(t => new Task { PathToFile = t }).ToList());
            dbMock.Setup(m => m.GetTask(0)).Returns(new List<Task>(0));

            var dbTaskManager = new DbTaskManager(dbMock.Object);

            var returnedTasks = dbTaskManager.GetTasks(zeroMaxCount);

            Assert.AreEqual(returnedTasks.Length, 0);
            dbMock.Verify(db => db.GetTask(zeroMaxCount), Times.Once);
        }
        
        
        [Test]
        public void WillReturnAsMuchOrLessThanMaxCountOnGetTasks()
        {
            string[] tasks = { "task1", "task2" };
            const int someMaxCount = 2;

            var dbMock = new Mock<ITaskManagerDBProvider>();
            dbMock.Setup(m => m.GetTask(It.IsAny<int>())).Returns(tasks.Select(t => new Task { PathToFile = t }).ToList());

            var dbTaskManager = new DbTaskManager(dbMock.Object);

            var returnedTasks = dbTaskManager.GetTasks(someMaxCount);

            Assert.LessOrEqual(returnedTasks.Length, someMaxCount);
            dbMock.Verify(db => db.GetTask(someMaxCount), Times.Once);
        }

        [Test]
        public void WillAddCorrectTasksOnAddTasks()
        {
            string[] tasks = { "task1", "task2" };

            var dbMock = new Mock<ITaskManagerDBProvider>();

            var dbTaskManager = new DbTaskManager(dbMock.Object);

            dbTaskManager.AddTasks(tasks);



            dbMock.Verify(db => db.InsertTask(It.IsAny<Task>(), It.IsAny<bool>()), Times.Exactly(2));
            foreach (var task in tasks)
            {
                dbMock.Verify(db => db.InsertTask(new Task{PathToFile = task}, false), Times.Once);
            }
        }
        
        [Test]
        public void WillAddCorrectTasksOnAddTasksWithHighPriority()
        {
            string[] tasks = { "task1", "task2" };

            var dbMock = new Mock<ITaskManagerDBProvider>();

            var dbTaskManager = new DbTaskManager(dbMock.Object);

            dbTaskManager.AddTasksWithHightPriority(tasks);


            dbMock.Verify(db => db.InsertTask(It.IsAny<Task>(), It.IsAny<bool>()), Times.Exactly(2));
            foreach (var task in tasks)
            {
                dbMock.Verify(db => db.InsertTask(new Task{PathToFile = task}, true), Times.Once);
            }

        }

    }
}