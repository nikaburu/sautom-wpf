using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace Sautom.Server
{
    internal class InjectedServiceHost : ServiceHost
    {
	    private readonly IUnityContainer _container;

	    protected InjectedServiceHost()
        {
        }

	    public InjectedServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            _container = container;
        }

	    protected override void OnOpening()
        {
            Description.Behaviors.Add(new InjectedBehavior(_container));
            base.OnOpening();
        }
    }

    internal class InjectedBehavior : IServiceBehavior
    {
	    private readonly IUnityContainer _container;

	    public InjectedBehavior(IUnityContainer container)
        {
            _container = container;
        }

	    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

	    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {

        }

	    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                foreach (EndpointDispatcher endpoint in channelDispatcher.Endpoints)
                {
                    if (endpoint.ContractName != "IMetadataExchange")
                    {
                        endpoint.DispatchRuntime.InstanceProvider =
                            new InjectedInstanceProvider(_container, serviceDescription.ServiceType);
                    }
                }
            }
        }
    }

    internal class InjectedInstanceProvider : IInstanceProvider
    {
	    private readonly IUnityContainer _container;
	    private readonly Type _contractType;

	    public InjectedInstanceProvider(IUnityContainer container, Type contractType)
        {
            _container = container;
            _contractType = contractType;
        }

	    public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

	    public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return _container.Resolve(_contractType);
        }

	    public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
			_container.Teardown(instance);
        }
    }
}