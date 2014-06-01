using System;
using System.Linq;
using System.ServiceModel;
using Sumo.Api;

namespace TaskService
{
        [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple)
    ]
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