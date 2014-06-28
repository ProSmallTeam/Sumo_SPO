using System;
using System.ServiceModel;
using Sumo.Api;

namespace BookService
{
    public class DbMetaManagerServiceHost : ServiceHost
    {
        public DbMetaManagerServiceHost(IBooksServiceContainer container, Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }


            var contracts = this.ImplementedContracts;

            var contractsValues = contracts.Values;

            foreach (var c in contractsValues)
            {
                var instanceProvider =
                    new DbMetaManagerInstanceProvider(
                        container);
                c.Behaviors.Add(instanceProvider);
            }
        }
    }
}