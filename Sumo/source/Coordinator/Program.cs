using System;
using System.ServiceModel;
using Sumo.Api;

namespace Coordinator
{
    /// <summary>
    /// Запрашивает задачи на добавление информации о книгах в б/д, запускает цепочки на их выполнение.
    /// </summary>
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
            var tcpUri = new Uri("http://localhost:1050/TaskService");

            var address = new EndpointAddress(tcpUri);
            var binding = new BasicHttpBinding();
            var factory = new ChannelFactory<IDbTaskManager>(binding, address);
            IDbTaskManager dbTaskManager = factory.CreateChannel();
            return dbTaskManager;
        }
    }
}