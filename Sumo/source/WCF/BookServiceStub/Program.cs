using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using BookService;
using DBMetaManager;
using Sumo.Api;

namespace BookServiceStub
{
    public  class Program
    {
        /// <summary>
        ///     Запускает WCF сервис.
        /// </summary>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hell0");
            ServiceHost dbMetaManagerHost = BookServiceHost.Get(typeof(MetaManagerStub));

            dbMetaManagerHost.Open();
            Console.WriteLine("Сервис запущен");


            Console.ReadKey();

            dbMetaManagerHost.Close();


            Console.WriteLine("Done");
        }
    }

}