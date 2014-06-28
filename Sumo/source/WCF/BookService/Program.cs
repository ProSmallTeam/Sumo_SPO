using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
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

            // var factory = new BooksServiceHostFactory();
            //var host = factory.CreateServiceHost(typeof(DbMetaManager).ToString(), new[] { new Uri(Sumo.Api.Resources.BookServiceHostAdress) } );
            var dbMetaManagerHost = new DbMetaManagerServiceHost(new DbMetaManagerServiceContainer(), typeof(DbMetaManager), new[] { new Uri(Sumo.Api.Resources.BookServiceHostAdress) });

            var wsHttpBinding = new WSHttpBinding();
            wsHttpBinding.ReliableSession.Enabled = true;

            dbMetaManagerHost.AddServiceEndpoint(typeof(IDbMetaManager).ToString(), wsHttpBinding, "");

            dbMetaManagerHost.Open();
            Console.WriteLine("Сервис запущен");

            
            Console.ReadKey();

            dbMetaManagerHost.Close();


            Console.WriteLine("Done");
        }
    }
}
