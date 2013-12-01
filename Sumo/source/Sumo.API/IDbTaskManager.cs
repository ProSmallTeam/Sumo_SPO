using System.Collections.Generic;
using System.ServiceModel;

namespace Sumo.API
{
    [ServiceContract]
    public interface IDbTaskManager
    {
        [OperationContract]
        string[] GetTasks(int maxCount);

        [OperationContract]
        void AddTasks(string[] pathsList);

        [OperationContract]
        void AddTasksWithHightPriority(string[] pathsList);

        //todo delete
        [OperationContract]
        string TestOperation(string str);

    }

}