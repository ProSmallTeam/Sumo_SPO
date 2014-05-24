using System;
using System.Security.Cryptography.X509Certificates;
using BookService;
using DBMetaManager;
using StructureMap;
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
            var type = typeof (MetaManagerStub);
            var addres = Resources.BookServiceHostAdress;

            IContainer container =new Container(x => x.For<App>().Use<App>()
                                               .Ctor<Type>().Is(type)
                                               );

            App app = container.With("Addres").EqualTo(addres).GetInstance<App>();

            app.Run();
           // var app = new App(typeof(MetaManagerStub));
          //  app.Addres = Resources.BookServiceHostAdress;
           // app.Run();
        }
     
    }



}