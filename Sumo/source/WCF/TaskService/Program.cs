using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Sumo.Api;

namespace TaskService
{
    class Program
    {
        /// <summary>
        /// Запускает WCF сервис.
        /// </summary>
        static void Main(string[] args)
        {

            Console.WriteLine("Hell0");

            var dbMetaManagerHost = GetHost(typeof(DbTaskManager));
            dbMetaManagerHost.Open();
            Console.WriteLine("Сервис запущен");


            Console.ReadKey();

            dbMetaManagerHost.Close();


            Console.WriteLine("Done");
        }

        public static ServiceHost GetHost(Type type)
        {
            // биндинг, позволяющий создавать сессии
            var wsHttpBinding = new WSHttpBinding();
            wsHttpBinding.ReliableSession.Enabled = true;

            var host = new ServiceHost(type, new Uri(Sumo.Api.Resources.TaskServiceHostAdress));
            host.AddServiceEndpoint(typeof(IDbTaskManager), wsHttpBinding, "");

            return host;
        }
    }

}
