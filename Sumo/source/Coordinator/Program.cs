using System;
using System.ServiceModel;
using Sumo.API;

namespace Coordinator
{
    internal class Program
    {
        public static void Main()
        {
            IDbTaskManager dbTaskManager = GetDbTaskManager();


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
            IDbTaskManager dbTaskManager = factory.CreateChannel();
            return dbTaskManager;
        }
    }
}