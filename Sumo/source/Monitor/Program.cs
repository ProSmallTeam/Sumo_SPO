using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using FileSystemObserver;
using Sumo.Api;

namespace Monitor
{
    class Program
    {
        internal class FileSystemObserverStub : IFileSystemObserver
        {
            public void Run()
            {
                return;
            }

            public void ExecuteEvent(List<string> pathList)
            {
                if (FoldersChanged == null)
                    return;

                var args = new FileObserverEventArgs(pathList);
                FoldersChanged(this, args);
            }

            public event FileObserverEventHandler FoldersChanged;
        }

        [STAThread]
        public static void Main()
        {
            var fileSystemObserver = new FileSystemObserverStub();

            var dbTaskManager = GetDbTaskManager();
            var monitor = new Monitor(fileSystemObserver, dbTaskManager);
            monitor.Run();

            var strings = new List<string>();

            Console.WriteLine("Введите пути(пустая строка - завершить)");

            while (true)
            {
                var str = Console.ReadLine();

                if (str == "")
                    break;

                strings.Add(str);

            }

            fileSystemObserver.ExecuteEvent(strings);

            //dbTaskManager.AddTasks(strings.ToArray());
            Console.WriteLine(dbTaskManager.TestOperation("asdf"));
            var a = dbTaskManager.GetTasks(10);
            foreach (var s in a)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Done");

            Console.ReadKey();
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
