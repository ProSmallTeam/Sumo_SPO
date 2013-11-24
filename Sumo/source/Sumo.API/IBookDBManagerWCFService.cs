using System.Collections.Generic;
using System.ServiceModel;

namespace Sumo.API
{
    [ServiceContract]
    public interface IBookDBManagerWCFService
    {
        [OperationContract]
        List<string> GetTasksForIndexing(int maxCount);

        [OperationContract]
        void AddTasksForIndexing(List<string> pathsList);

        [OperationContract]
        void AddTasksForIndexingWithHightPriority(List<string> pathsList);

        //todo delete
        [OperationContract]
        string TestOperation(string str);

    }

}