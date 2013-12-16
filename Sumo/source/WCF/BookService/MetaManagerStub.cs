using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using Sumo.API;

namespace BookService
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class MetaManagerStub : IDbMetaManager
    {
        private int _operationsCounter = 0;
        public SumoSession CreateQuery(string query)
        {
            _operationsCounter++;
            var session = new SumoSession {SessionId = 10, Count = _operationsCounter};
            return session;
        }

        public List<Book> GetDocuments(int sessionId, int count, int offset = 0)
        {
            _operationsCounter++;

            var book = new Book();
            var list = new List<Book>();

            for (int i = 0; i < count; i++)
            {
                list.Add(book);
            }

            return list;
        }

        public CategoriesMultiList GetStatistic(int sessionId)
        {

            _operationsCounter++;

            var a = new CategoryNode {Id = sessionId};

            var list1 = new CategoriesMultiList(a);
            var list2 = new CategoriesMultiList(new CategoryNode(), new List<CategoriesMultiList>{list1});

            return list2;
        }

        public void CloseSession(SumoSession session)
        {
            _operationsCounter++;

            Trace.WriteLine("CloseSession called");
        }

    }
}