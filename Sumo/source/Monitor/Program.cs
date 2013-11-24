using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Sumo.API;

namespace Monitor
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            Uri tcpUri = new Uri("http://localhost:1050/TestService");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            var factory = new ChannelFactory<IBookDBManagerWCFService>(binding, address);
            var service = factory.CreateChannel();

            Console.WriteLine("Вызываю метод сервиса...?");
            Console.WriteLine(service.TestOperation("1"));
            Console.WriteLine(service.TestOperation("3"));
            Console.WriteLine(service.TestOperation("2"));
            Console.ReadLine();
        }
    }
}
