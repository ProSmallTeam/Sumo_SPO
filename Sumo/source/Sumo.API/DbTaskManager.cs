using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.ServiceModel;
using Sumo.API;

namespace Sumo.API
{
    /// <summary>
    /// Простейшая реализация IDbTaskManager.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DbTaskManager : IDbTaskManager
    {
        private static string[] _tasks = new string[50];
        private int _counter = 0;
        public DbTaskManager()
        {
            _tasks = new string[50];
        }

        public string[] GetTasks(int maxCount)
        {
            return _tasks;
        }

        public void AddTasks(string[] pathsList)
        {
            _tasks = pathsList;
            _counter++;
        }

        public void AddTasksWithHightPriority(string[] pathsList)
        {
            _tasks = pathsList;
            
        }

        public string TestOperation(string str)
        {
            return str + "Hell0 " + _tasks.Count(s => !String.IsNullOrEmpty(s)) + " "
                + _counter;
        }
    }
}
