//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://tempuri.org/service/", ConfigurationName="ServiceReference1.ITheService")]
    public interface ITheService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/service/ITheService/CheckSomeThing", ReplyAction="http://tempuri.org/service/ITheService/CheckSomeThingResponse")]
        ServiceReference1.TheResponseType CheckSomeThing(ServiceReference1.TheServiceRequestType request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/service/ITheService/CheckSomeThing", ReplyAction="http://tempuri.org/service/ITheService/CheckSomeThingResponse")]
        System.Threading.Tasks.Task<ServiceReference1.TheResponseType> CheckSomeThingAsync(ServiceReference1.TheServiceRequestType request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TheServiceRequest", WrapperNamespace="http://tempuri.org/service/", IsWrapped=true)]
    public partial class TheServiceRequestType
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/service/", Order=0)]
        public bool BoolValue;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/service/", Order=1)]
        public string StringValue;
        
        public TheServiceRequestType()
        {
        }
        
        public TheServiceRequestType(bool BoolValue, string StringValue)
        {
            this.BoolValue = BoolValue;
            this.StringValue = StringValue;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TheResponse", WrapperNamespace="http://tempuri.org/service/", IsWrapped=true)]
    public partial class TheResponseType
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/service/", Order=0)]
        public bool BoolValue;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/service/", Order=1)]
        public string StringValue;
        
        public TheResponseType()
        {
        }
        
        public TheResponseType(bool BoolValue, string StringValue)
        {
            this.BoolValue = BoolValue;
            this.StringValue = StringValue;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface ITheServiceChannel : ServiceReference1.ITheService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class TheServiceClient : System.ServiceModel.ClientBase<ServiceReference1.ITheService>, ServiceReference1.ITheService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TheServiceClient() : 
                base(TheServiceClient.GetDefaultBinding(), TheServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.CustomBinding_ITheService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TheServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(TheServiceClient.GetBindingForEndpoint(endpointConfiguration), TheServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TheServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TheServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TheServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TheServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TheServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public ServiceReference1.TheResponseType CheckSomeThing(ServiceReference1.TheServiceRequestType request)
        {
            return base.Channel.CheckSomeThing(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.TheResponseType> CheckSomeThingAsync(ServiceReference1.TheServiceRequestType request)
        {
            return base.Channel.CheckSomeThingAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CustomBinding_ITheService))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TransportSecurityBindingElement userNameOverTransportSecurityBindingElement = System.ServiceModel.Channels.SecurityBindingElement.CreateUserNameOverTransportBindingElement();
                userNameOverTransportSecurityBindingElement.MessageSecurityVersion = System.ServiceModel.MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
                userNameOverTransportSecurityBindingElement.SecurityHeaderLayout = System.ServiceModel.Channels.SecurityHeaderLayout.Lax;
                result.Elements.Add(userNameOverTransportSecurityBindingElement);
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CustomBinding_ITheService))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:58963/TheService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TheServiceClient.GetBindingForEndpoint(EndpointConfiguration.CustomBinding_ITheService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TheServiceClient.GetEndpointAddress(EndpointConfiguration.CustomBinding_ITheService);
        }
        
        public enum EndpointConfiguration
        {
            
            CustomBinding_ITheService,
        }
    }
}
