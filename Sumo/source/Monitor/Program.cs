using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using FileSystemObserver;
using Sumo.API;

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

            var monitor = new Monitor(fileSystemObserver, GetDbTaskManager());
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
