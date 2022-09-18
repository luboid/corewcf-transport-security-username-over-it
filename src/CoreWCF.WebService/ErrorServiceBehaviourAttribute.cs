using System;
using System.Collections.ObjectModel;
using System.Reflection;
using CoreWCF.Channels;
using CoreWCF.Description;
using CoreWCF.Dispatcher;
using Microsoft.Extensions.DependencyInjection;

namespace CoreWCF.WebService
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class ErrorServiceBehaviourAttribute : Attribute, IServiceBehavior
    {
        private readonly Type errorHandlerType;
        private readonly PropertyInfo ServiceProviderProperty = typeof(ServiceDescription)
            .GetProperty("ServiceProvider", BindingFlags.Instance | BindingFlags.NonPublic);

        public ErrorServiceBehaviourAttribute(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var serviceProvider = ServiceProviderProperty.GetValue(serviceDescription) as IServiceProvider;
            var errorHandler = serviceProvider.GetRequiredService(errorHandlerType) as IErrorHandler;
            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(errorHandler);
            }
        }
    }
}