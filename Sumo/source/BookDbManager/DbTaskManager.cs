using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.ServiceModel;
using Sumo.API;

namespace BookDbManager
{
    public class DbTaskManager : IDbTaskManager
    {
        private static List<string> _tasks;

        public DbTaskManager()
        {
            _tasks = new List<string>();
        }

        public List<string> GetTasks(int maxCount)
        {
            return _tasks;
//            var tasks = _tasks;
            //          _tasks = new List<string>();
            //        return tasks;

        }

        public void AddTasks(List<string> pathsList)
        {
            _tasks = pathsList;
        }

        public void AddTasksWithHightPriority(List<string> pathsList)
        {
            _tasks = pathsList;
            
        }

        public string TestOperation(string str)
        {
            return str + "Hell0" + _tasks.Count;
        }
    }
}
