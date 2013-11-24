using System;
using System.Collections.Generic;
using System.ServiceModel;
using Sumo.API;

namespace BookDbManager
{
    public class BookDbManagerService: IBookDBManagerWCFService
    {
        public List<string> GetTasksForIndexing(int maxCount)
        {
            throw new NotImplementedException();
        }

        public void AddTasksForIndexing(List<string> pathsList)
        {
            throw new NotImplementedException();
        }

        public void AddTasksForIndexingWithHightPriority(List<string> pathsList)
        {
            throw new NotImplementedException();
        }

        public string TestOperation(string str)
        {
            return str + "Hell0";
        }
    }
}
