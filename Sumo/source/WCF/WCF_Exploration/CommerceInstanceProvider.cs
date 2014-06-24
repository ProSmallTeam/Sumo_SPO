using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WCF_Exploration
{
    public partial class CommerceInstanceProvider :
        IInstanceProvider, IContractBehavior
    {
        private readonly ICommerceServiceContainer container;
        public CommerceInstanceProvider(
            ICommerceServiceContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }


        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.GetInstance(instanceContext);
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return this.container
            .ResolveProductManagementService();
        }
        public void ReleaseInstance(InstanceContext instanceContext,
        object instance)
        {
            this.container.Release(instance);
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            throw new NotImplementedException();
        }

        public void ApplyDispatchBehavior( ContractDescription contractDescription, 
            ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            throw new NotImplementedException();
        }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint,
            BindingParameterCollection bindingParameters)
        {
            throw new NotImplementedException();
        }
    }
}