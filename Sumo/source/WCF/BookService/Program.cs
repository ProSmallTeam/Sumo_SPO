using System;
using System.ServiceModel;
using DB;
using DBMetaManager;
using Sumo.Api;

namespace BookService
{
    class Program
    {
        /// <summary>
        /// Запускает WCF сервис.
        /// </summary>
        static void Main(string[] args)
        {

            Console.WriteLine("Hell0");
            var dbMetaManagerHost = CreateDbMetaManagerHost();

            dbMetaManagerHost.Open();
            Console.WriteLine("Сервис запущен");

            
            Console.ReadKey();

            dbMetaManagerHost.Close();


            Console.WriteLine("Done");
        }

        private static ServiceHost CreateDbMetaManagerHost()
        {
            var metaManager = new DbMetaManager(new DataBase(Resourses.MongoConnectionString));

            var host = new ServiceHost(metaManager, new Uri("http://localhost:1060/TestService"));
            host.AddServiceEndpoint(typeof(IDbMetaManager), new BasicHttpBinding(), "");
            return host;
        }
    }
}
