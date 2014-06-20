using System.Collections.Generic;

namespace Sumo.Api
{
    public interface ITaskManagerDBProvider
    {
        int InsertTask(Task task, bool flagOfHighPriority);
        int RemoveTask(Task task);
        List<Task> GetTask(int quantity);
    }
}