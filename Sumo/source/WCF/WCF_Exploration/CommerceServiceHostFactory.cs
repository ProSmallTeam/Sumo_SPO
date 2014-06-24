using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace WCF_Exploration
{
    public class CommerceServiceHostFactory : ServiceHostFactory
    {
        private readonly ICommerceServiceContainer container;
        public CommerceServiceHostFactory()
        {
            this.container =
                new CommerceServiceContainer();
        }
        protected override ServiceHost CreateServiceHost(
            Type serviceType, Uri[] baseAddresses)
        {
            if (serviceType == typeof(ProductManagementService))
            {
                return new CommerceServiceHost(
                    this.container,
                    serviceType, baseAddresses);
            }
            return base.CreateServiceHost(serviceType, baseAddresses);
        }
    }
}