using System.Linq;
using System.ServiceModel;
using Sumo.Api;

namespace DBTaskManager
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple)
    ]
    public class DbTaskManager : IDbTaskManager
    {
        private readonly ITaskManagerDBProvider _dataBase;


        public DbTaskManager(ITaskManagerDBProvider dataBase)
        {
            _dataBase = dataBase;
        }


        public string[] GetTasks(int maxCount)
        {
            return _dataBase.GetTask(maxCount).Select(t => t.PathToFile).ToArray();
        }

        public void AddTasks(string[] pathsList)
        {
            foreach (var task in pathsList)
            {
                _dataBase.InsertTask(new Task {PathToFile = task}, false);
            }
        }

        public void AddTasksWithHightPriority(string[] pathsList)
        {
            foreach (var task in pathsList)
            {
                _dataBase.InsertTask(new Task { PathToFile = task }, true);
            }
        }

        public string TestOperation(string str)
        {
            return str + " correct";
        }
    }
}