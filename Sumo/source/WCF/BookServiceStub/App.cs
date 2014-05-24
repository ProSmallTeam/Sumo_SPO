using System;
using System.ServiceModel;
using Sumo.Api;

namespace BookServiceStub
{
    public class App
    {
        public App(Type hostType)
        {
            HostType = hostType;
        }

        public Type HostType { get; set; }
        public string Addres { get; set; }

        public ServiceHost GetHost()
        {
            // биндинг, позволяющий создавать сессии
            var wsHttpBinding = new WSHttpBinding();
            wsHttpBinding.ReliableSession.Enabled = true;

            var host = new ServiceHost(HostType, new Uri(Addres));
            host.AddServiceEndpoint(typeof(IDbMetaManager), wsHttpBinding, "");

            return host;
        }

        public void Run()
        {
            Console.WriteLine("Hell0");
            ServiceHost dbMetaManagerHost = GetHost();

            dbMetaManagerHost.Open();
            Console.WriteLine("Сервис запущен");


            Console.ReadKey();

            dbMetaManagerHost.Close();


            Console.WriteLine("Done");
        }
    }
}