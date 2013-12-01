using System;
using System.Collections.Generic;
using System.Linq;
using Sumo.API;

namespace Coordinator
{
    public class Coordinator
    {
        private readonly IDbTaskManager _dbTaskManager;
        private List<string> _tasks = new List<string>();

        public Coordinator(IDbTaskManager dbTaskManager)
        {
            _dbTaskManager = dbTaskManager;
        }

        public void Run()
        {
            var tasks = (IEnumerable<string>)_dbTaskManager.GetTasks(10);
            var t  = _tasks.Concat(tasks);
            _tasks = t.ToList();
            //_tasks = tasks.ToList();
        }

        public void ExecuteTasks()
        {
            foreach (var task in _tasks)
            {
                Console.WriteLine("Выполнение: " + task);
            }
        }
    }
}