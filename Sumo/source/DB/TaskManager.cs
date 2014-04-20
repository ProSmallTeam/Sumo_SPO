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
        private static void UpdateTask(MongoCollection<BsonDocument> collection ,IEnumerable<Task> tasks)
        {
            var update = Update.Set("Receipt", true);
            foreach (var query in tasks.Select(task => new QueryDocument(new BsonDocument { { "Path", task.PathToFile } })))
            {
                collection.Update(query, update, UpdateFlags.Multi);
            }
        }

        public static List<Task> GetTask(MongoCollection<BsonDocument> collection, int quantity)
        {
            const int HighPriority = 1;
            const int LowPriority = 0;

            var query = new QueryDocument(new BsonDocument { { "Priority", HighPriority }, { "Receipt", false } });
            var tempList = collection.FindAs<BsonDocument>(query).SetLimit(quantity).ToList();

            var result = tempList.Select(task => new Task { PathToFile = task["Path"].ToString() }).ToList();

            var count = result.Count;

            if (count < quantity)
            {
                query = new QueryDocument(new BsonDocument { { "Priority", LowPriority }, { "Receipt", false } });
                tempList = collection.FindAs<BsonDocument>(query).SetLimit(quantity - count).ToList();

                result.AddRange(tempList.Select(task => new Task { PathToFile = task["Path"].ToString() }));
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
    }
}
