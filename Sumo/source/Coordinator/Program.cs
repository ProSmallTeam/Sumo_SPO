using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Sumo.API;

namespace Coordinator
{
    class Program
    {
        public static void Main()
        {
            var dbTaskManager = GetDbTaskManager();


            var coordinator = new Coordinator(dbTaskManager);

            Console.WriteLine("Нажмите любую кнопку для запуска");
            Console.ReadKey();

            coordinator.Run();
            coordinator.ExecuteTasks();

            Console.WriteLine("Завершено");
        }

        private static IDbTaskManager GetDbTaskManager()
        {
            var tcpUri = new Uri("http://localhost:1050/TestService");

            var address = new EndpointAddress(tcpUri);
            var binding = new BasicHttpBinding();
            var factory = new ChannelFactory<IDbTaskManager>(binding, address);
            var dbTaskManager = factory.CreateChannel();
            return dbTaskManager;
        }
    }
}
