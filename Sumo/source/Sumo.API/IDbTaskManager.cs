using System.Collections.Generic;
using System.ServiceModel;

namespace Sumo.Api
{
    // Разбить на 2 интерфейса.
    /// <summary>
    /// Получает или дает задачи базе данных на добавление книг.
    /// </summary>
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