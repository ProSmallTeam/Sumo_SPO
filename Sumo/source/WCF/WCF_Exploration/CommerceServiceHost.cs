using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCF_Exploration
{
    public class CommerceServiceHost : ServiceHost
    {
        public CommerceServiceHost(ICommerceServiceContainer container,
            Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            ICollection<ContractDescription> contracts = ImplementedContracts.Values;
            foreach (ContractDescription c in contracts)
            {
                var instanceProvider =
                    new CommerceInstanceProvider(
                        container);
                c.Behaviors.Add(instanceProvider);
            }
        }
    }
}