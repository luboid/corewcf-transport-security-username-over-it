using System;
using CoreWCF.Channels;
using CoreWCF.Dispatcher;
using Microsoft.Extensions.Logging;

namespace CoreWCF.WebService
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly ILogger<ErrorHandler> _logger;

        public ErrorHandler(ILogger<ErrorHandler> logger)
        {
            this._logger = logger;
        }

        public bool HandleError(Exception error)
        {
            _logger.LogError(error, "Unexpected exception.");
            return false;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            _logger.LogError(error, "Unexpected exception.");
        }
    }
}