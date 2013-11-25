using System.Collections.Generic;
using System.ServiceModel;

namespace Sumo.API
{
    [ServiceContract]
    public interface IDbTaskManager
    {
        [OperationContract]
        List<string> GetTasks(int maxCount);

        [OperationContract]
        void AddTasks(List<string> pathsList);

        [OperationContract]
        void AddTasksWithHightPriority(List<string> pathsList);

        //todo delete
        [OperationContract]
        string TestOperation(string str);

    }

}