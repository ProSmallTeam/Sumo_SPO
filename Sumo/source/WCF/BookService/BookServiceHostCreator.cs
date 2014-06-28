using System;
using System.ServiceModel;
using DBMetaManager;
using Sumo.Api;
using WCF_Exploration;

namespace BookService
{
    public static class BookServiceHostCreator
    {
        public static ServiceHostBase Get(Type type)
        {
           // var factory = new BooksServiceHostFactory();
            //var host = factory.CreateServiceHost(typeof(DbMetaManager).ToString(), new[] { new Uri(Sumo.Api.Resources.BookServiceHostAdress) } );

            var host = new DbMetaManagerServiceHost(new ReleasingBooksServiceContainer(), type, new[] { new Uri(Sumo.Api.Resources.BookServiceHostAdress) });

            var wsHttpBinding = new WSHttpBinding();
            wsHttpBinding.ReliableSession.Enabled = true;

            host.AddServiceEndpoint(typeof (IDbMetaManager).ToString(), wsHttpBinding, "");

            return host;

            //// биндинг, позволяющий создавать сессии
            //var wsHttpBinding = new WSHttpBinding();
            //wsHttpBinding.ReliableSession.Enabled = true;

            //var host = new ServiceHost(type, new Uri(Sumo.Api.Resources.BookServiceHostAdress));
            //host.AddServiceEndpoint(typeof(IDbMetaManager), wsHttpBinding, "");

            //return (ServiceHostBase)host;
        }
    }
}