using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using DBMetaManager;

namespace BookService
{
    public class BooksServiceHostFactory : ServiceHostFactory
    {
        private readonly IBooksServiceContainer _container;

        public BooksServiceHostFactory()
        {
            _container = new ReleasingBooksServiceContainer();
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            if (serviceType == typeof (DbMetaManager))
            {
                return new DbMetaManagerServiceHost(_container, serviceType, baseAddresses);
            }
            return base.CreateServiceHost(serviceType, baseAddresses);
        }
    }
}