using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using Sumo.API;

namespace BookService
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class MetaManagerStub : IDbMetaManager
    {
        public SumoSession CreateQuery(string query)
        {
            var session = new SumoSession {SessionId = 10, Count = 30};
            return session;
        }

        public List<Book> GetDocuments(int sessionId, int count, int offset = 0)
        {
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

            var list1 = new CategoriesMultiList(new CategoryNode());
            var list2 = new CategoriesMultiList(new CategoryNode(), new List<CategoriesMultiList>{list1});

            return list2;
        }

        public void CloseSession(SumoSession session)
        {
            Trace.WriteLine("CloseSession called");
        }

    }
}