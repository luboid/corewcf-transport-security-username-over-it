using CoreWCF.Description;
using CoreWCF.Dispatcher;
using CoreWCF.Security;

namespace CoreWCF.WebService.Extensions
{
    public static class ServiceHostExtensions
    {
        public static void ApplyUserValidator(this ServiceHostBase serviceHostBase, CoreWCF.WebService.UserNamePasswordValidator userNamePasswordValidator)
        {
            var srvCredentials = new ServiceCredentials();
            srvCredentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
            srvCredentials.UserNameAuthentication.CustomUserNamePasswordValidator = userNamePasswordValidator;

            serviceHostBase.Description.Behaviors.Add(srvCredentials);
        }

        public static void ApplyErrorHandler(this ServiceHostBase serviceHostBase, IErrorHandler errorHandler)
        {
            foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(errorHandler);
            }
        }
    }
}
