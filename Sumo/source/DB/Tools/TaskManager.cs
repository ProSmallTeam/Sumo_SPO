using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Task = Sumo.Api.Task;

namespace DB
{
    internal static class TaskManager
    {
        public static List<Task> GetTask(MongoCollection<BsonDocument> collection, int quantity)
        {
            var result = GetTaskWithHighPriority(collection, quantity);

            var count = result.Count;

            if (count < quantity)
            {
                var tasks = GetTaskWithLowPriority(collection, quantity - count);

                result.AddRange(tasks);
            }

            UpdateTask(collection, result);

            return result;
        }

        
        public static int RemoveTask(MongoCollection<BsonDocument> collection, Task task)
        {
            var query = new QueryDocument(new BsonDocument { { "Path", task.PathToFile } });

            try
            {
                collection.Remove(query);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int InsertTask(MongoCollection<BsonDocument> collection, Task task, bool flagOfHighPriority = false)
        {
            var priority = flagOfHighPriority ? 1 : 0;

            var _task = new BsonDocument
                                     {
                                         {"Path", task.PathToFile}, 
                                         {"Priority", priority}, 
                                         {"Receipt", false}
                                     };
            try
            {
                collection.Insert(_task);

                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        private static List<Task> GetTaskWithLowPriority(MongoCollection<BsonDocument> collection, int quantity)
        {
            const int lowPriority = 0;

            var query = new QueryDocument(new BsonDocument { { "Priority", lowPriority }, { "Receipt", false } });
            var tempList = collection.FindAs<BsonDocument>(query).SetLimit(quantity).ToList();

            var tasks = tempList.Select(task => new Task { PathToFile = task["Path"].ToString() }).ToList();
            return tasks;
        }

        private static List<Task> GetTaskWithHighPriority(MongoCollection<BsonDocument> collection, int quantity)
        {
            const int highPriority = 1;

            var query = new QueryDocument(new BsonDocument { { "Priority", highPriority }, { "Receipt", false } });
            var tempList = collection.FindAs<BsonDocument>(query).SetLimit(quantity).ToList();

            var result = tempList.Select(task => new Task { PathToFile = task["Path"].ToString() }).ToList();
            return result;
        }

        private static void UpdateTask(MongoCollection<BsonDocument> collection, IEnumerable<Task> tasks)
        {
            var update = Update.Set("Receipt", true);
            foreach (var query in tasks.Select(task => new QueryDocument(new BsonDocument { { "Path", task.PathToFile } })))
            {
                collection.Update(query, update, UpdateFlags.Multi);
            }
        }

    }
}
