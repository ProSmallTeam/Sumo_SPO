using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Task = Sumo.Api.Task;

namespace DB
{
    internal class TaskManager
    {
        private MongoCollection<BsonDocument> Tasks;

        public TaskManager(MongoCollection<BsonDocument> tasks)
        {
            Tasks = tasks;
        }

        public List<Task> Get(int quantity)
        {
            var result = GetTaskWithHighPriority(Tasks, quantity);

            var count = result.Count;

            if (count < quantity)
            {
                var tasks = GetTaskWithLowPriority(this.Tasks, quantity - count);

                result.AddRange(tasks);
            }

            UpdateTask(Tasks, result);

            return result;
        }

        
        public int RemoveTask(Task task)
        {
            var query = new QueryDocument(new BsonDocument { { "Path", task.PathToFile } });

            try
            {
                Tasks.Remove(query);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int InsertTask(Task task, bool flagOfHighPriority = false)
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
                Tasks.Insert(_task);

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
