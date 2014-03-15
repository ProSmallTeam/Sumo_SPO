using System;
using System.ServiceModel;
using Sumo.API;

namespace BookServiceStub
{
    internal class Program
    {
        /// <summary>
        ///     Запускает WCF сервис.
        /// </summary>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hell0");
            ServiceHost dbMetaManagerHost = CreateDbMetaManagerHost(typeof (MetaManagerStub));

            dbMetaManagerHost.Open();
            Console.WriteLine("Сервис запущен");


            Console.ReadKey();

            dbMetaManagerHost.Close();


            Console.WriteLine("Done");
        }

        private static ServiceHost CreateDbMetaManagerHost(Type type)
        {
            var host = new ServiceHost(type, new Uri("http://localhost:1060/TestService"));
            host.AddServiceEndpoint(typeof (IDbMetaManager), new BasicHttpBinding(), "");
            return host;
        }
    }
}