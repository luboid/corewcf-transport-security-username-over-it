using System;
using System.Threading.Tasks;
using CoreWCF.Dispatcher;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CoreWCF.WebService.Configuration;

namespace CoreWCF.WebService
{
    [ServiceBehavior(Namespace = Namespaces.Data, InstanceContextMode = InstanceContextMode.PerCall)]
    public sealed class TheService : ITheService, ITheServiceAsync, IDisposable
    {
        private readonly CoreWCFSettings _options;
        private readonly ILogger<TheService> _logger;

        public TheService(
            IOptionsMonitor<CoreWCFSettings> options,
            ILogger<TheService> logger)
        {
            _options = options?.CurrentValue ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public TheResponseType CheckSomeThing(TheServiceRequestType request)
        {
            return new TheResponseType
            {
                BoolValue = request?.BoolValue == true,
                StringValue = (request?.StringValue ?? "empty request") + " ... echo",
            };
        }

        public async Task<TheResponseType> CheckSomeThingAsync(TheServiceRequestType request)
        {
            await Task.Delay(100);

            return new TheResponseType
            {
                BoolValue = request?.BoolValue == true,
                StringValue = (request?.StringValue ?? "empty request") + " ... echo",
            };
        }

        public void Dispose()
        {
        }
    }
}