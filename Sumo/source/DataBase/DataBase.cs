using System;

namespace InitializeDataBase
{
    using MongoDB.Driver;


    public class DataBase
    {
        public readonly MongoDatabase database;

        private const string NameOfDataBase = "library";

        private MongoCollection<Type> currentCollection { get; set; }

        public DataBase(string connectiongString)
        {
            var server = MongoServer.Create(connectiongString);

            database = server.GetDatabase(NameOfDataBase);
        }

        public MongoCollection GetCollection(string collection)
        {
            currentCollection = database.GetCollection<Type>(collection);
            return currentCollection;
        }

        public void Drop()
        {
            database.Drop();
        }
    }
}
