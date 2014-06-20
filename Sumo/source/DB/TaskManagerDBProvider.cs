using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Sumo.Api;

namespace DB
{
    internal class TaskManagerDBProvider : ITaskManagerDBProvider
    {
        private MongoCollection<BsonDocument> Tasks;

        public TaskManagerDBProvider(MongoCollection<BsonDocument> tasks)
        {
            Tasks = tasks;
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

        public List<Task> GetTask(int quantity)
        {

            var result = GetTaskWithHighPriority(quantity);

            var count = result.Count;

            if (count < quantity)
            {
                var tasks = GetTaskWithLowPriority(quantity - count);
                result.AddRange(tasks);
            }

            UpdateTask(result);

            return result;
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

        private List<Task> GetTaskWithLowPriority(int quantity)
        {
            const int lowPriority = 0;

            var tasks = GetTasks(quantity, lowPriority);
            return tasks;
        }

        private List<Task> GetTaskWithHighPriority(int quantity)
        {
            const int highPriority = 1;

            var tasks = GetTasks(quantity, highPriority);
            return tasks;
        }

        private List<Task> GetTasks(int quantity, int priority)
        {
            var tempList = FindTasks(quantity, priority);

            var tasks = BsdToTask(tempList);
            return tasks;
        }

        private List<BsonDocument> FindTasks(int quantity, int priority)
        {
            var query = new QueryDocument(new BsonDocument {{"Priority", priority}, {"Receipt", false}});
            var tempList = Find(query, quantity);

            return tempList;
        }

        private List<BsonDocument> Find(QueryDocument query, int quantity)
        {
            return Tasks.FindAs<BsonDocument>(query).SetLimit(quantity).ToList();
        }

        private static List<Task> BsdToTask(List<BsonDocument> tempList)
        {
            return tempList.Select(task => new Task {PathToFile = task["Path"].ToString()}).ToList();
        }

        private void UpdateTask(IEnumerable<Task> tasks)
        {
            var update = Update.Set("Receipt", true);
            foreach (var query in tasks.Select(task => new QueryDocument(new BsonDocument { { "Path", task.PathToFile } })))
            {
                Tasks.Update(query, update, UpdateFlags.Multi);
            }
        }

    }
}