using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using BookService;
using DBMetaManager;
using StructureMap;
using Sumo.Api;

namespace BookServiceStub
{
    public  class Program
    {
      //  /// <summary>
     //   ///     Запускает WCF сервис.
       // /// </summary>
        //private static void Main(string[] args)
        //{
        //    var type = typeof (MetaManagerStub);
        //    var addres = Resources.BookServiceHostAdress;

        //    IContainer container = new Container(x => x.For<App>().Use<App>()
        //                                       .Ctor<Type>().Is(type)
        //                                       );

        //    App app = container.With("Addres").EqualTo(addres).GetInstance<App>();

        //    app.Run();
        //}


        /// <summary>
        ///     Запускает WCF сервис.
        /// </summary>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hell0");

            // var factory = new BooksServiceHostFactory();
            //var host = factory.CreateServiceHost(typeof(DbMetaManager).ToString(), new[] { new Uri(Sumo.Api.Resources.BookServiceHostAdress) } );
            var dbMetaManagerHost = new DbMetaManagerServiceHost(new StubbingDbMetaManagerServiceContainer(), typeof(DbMetaManager), new[] { new Uri(Sumo.Api.Resources.BookServiceHostAdress) });

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