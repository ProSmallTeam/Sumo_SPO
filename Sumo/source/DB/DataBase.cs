using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sumo.Api;

namespace DB
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class DataBase : IDataBase
    {
        public MongoDatabase Database;

        private readonly string _nameOfDataBase;

        private readonly BookMeta bookMeta;

        #region Коллекции

        // Коллекция, в которой хранится информация о книгах.
        public static MongoCollection<BsonDocument> Books;

        // Коллекция, в которой хранится всесь список аттрибутов.
        public static MongoCollection<BsonDocument> Attributes;

        // Коллекция, в которой хранятся прочие данные о книгах.
        public static MongoCollection<BsonDocument> AlternativeMeta;

        // Колекция, в которой хранятся задания на обработку книг.
        public static MongoCollection<BsonDocument> Tasks;

        #endregion
        
        public DataBase(string connectiongString, string nameOfDataBase = Resources.MongoDataBaseName)
        {
            var client = new MongoClient(connectiongString);
            var server = client.GetServer();

            _nameOfDataBase = nameOfDataBase;

            Database = server.GetDatabase(_nameOfDataBase);

            SetCollections();

            bookMeta = new BookMeta(Books, AlternativeMeta);
        }

        #region BookMeta

        public int SaveBookMeta(Book book, List<Book> alternativeBook = null)
        {
            return bookMeta.SaveBookMeta(book, alternativeBook);
        }

        public int DeleteBookMeta(string md5Hash)
        {
            return bookMeta.DeleteBookMeta(md5Hash);
        }

        public bool IsHaveBookMeta(string md5Hash)
        {
            return bookMeta.IsHaveBookMeta(md5Hash);
        }

        public List<Book> GetBooks(string query, int limit = 0, int offset = 0)
        {
            return bookMeta.GetBooks(query, limit, offset);
        }

        #endregion

        #region Statistic

        public int GetStatistic(string query)
        {
            return new StatisticTools().GetStatistic(query);
        }

        public CategoriesMultiList GetStatisticTree(string query)
        {
            return new StatisticTools().GetStatisticTree(query);
        }

        #endregion      

        #region Task

        public int InsertTask(Task task, bool flagOfHighPriority = false)
        {
            return TaskManager.InsertTask(Tasks, task, flagOfHighPriority);
        }

        public int RemoveTask(Task task)
        {
            return TaskManager.RemoveTask(Tasks, task);
        }

        public List<Task> GetTask(int quantity)
        {
            return TaskManager.Get(Tasks, quantity);
        }

        #endregion

        #region DbTools

        public void Indexing()
        {
            Books.EnsureIndex(new IndexKeysBuilder().Ascending("Attributes"));
            Attributes.EnsureIndex(new IndexKeysBuilder().Ascending("_id"));
            Attributes.EnsureIndex(new IndexKeysBuilder().Ascending("FatherRef"));
            AlternativeMeta.EnsureIndex(new IndexKeysBuilder().Ascending("_id"));
        }

        private void SetCollections()
        {
            Books = Database.GetCollection<BsonDocument>("Books");

            Attributes = Database.GetCollection<BsonDocument>("Attributes");

            AlternativeMeta = Database.GetCollection<BsonDocument>("AlternativeMeta");

            Tasks = Database.GetCollection<BsonDocument>("Tasks");

        }

        public void Drop()
        {
            Database.Drop();
        }
        
        #endregion
    }
}


