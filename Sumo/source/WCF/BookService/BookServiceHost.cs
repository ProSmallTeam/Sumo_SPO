using System;
using System.ServiceModel;
using Sumo.Api;

namespace BookService
{
    public static class BookServiceHost
    {
        public static ServiceHost Get(Type type)
        {
            // биндинг, позволяющий создавать сессии
            var wsHttpBinding = new WSHttpBinding();
            wsHttpBinding.ReliableSession.Enabled = true;

            var host = new ServiceHost(type, new Uri(Sumo.Api.Resources.BookServiceHostAdress));
            host.AddServiceEndpoint(typeof(IDbMetaManager), wsHttpBinding, "");

            return host;
        }
    }
}