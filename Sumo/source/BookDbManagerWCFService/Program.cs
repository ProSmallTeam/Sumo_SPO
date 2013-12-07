using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Sumo.API;

namespace BookDbManagerWCFService
{
    class Program
    {
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
        static void Main(string[] args)
        {

            Console.WriteLine("Hell0");
            var dbTaskManagerHost = CreateDbTaskManagerHost();
            var dbMetaManagerHost = CreateDbMetaManagerHost(typeof(MetaManagerStub));

            dbTaskManagerHost.Open();
            Console.WriteLine("Сервер1 запущен");

            dbMetaManagerHost.Open();
            Console.WriteLine("Сервер2 запущен");

            
            Console.ReadKey();

            dbTaskManagerHost.Close();
            dbMetaManagerHost.Close();


            Console.WriteLine("Done");
        }

        private static ServiceHost CreateDbTaskManagerHost()
        {
            var host = new ServiceHost(typeof (Sumo.API.DbTaskManager), new Uri("http://localhost:1050/TestService"));
            host.AddServiceEndpoint(typeof (Sumo.API.IDbTaskManager), new BasicHttpBinding(), "");
            return host;
        }
        private static ServiceHost CreateDbMetaManagerHost(Type type)
        {
            var host = new ServiceHost(type, new Uri("http://localhost:1060/TestService"));
            host.AddServiceEndpoint(typeof(Sumo.API.IDbMetaManager), new BasicHttpBinding(), "");
            return host;
        }
    }
}
