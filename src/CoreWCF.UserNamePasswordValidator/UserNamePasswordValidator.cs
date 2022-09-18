using CoreWCF.WebService.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CoreWCF.WebService
{
    public class UserNamePasswordValidator : CoreWCF.IdentityModel.Selectors.UserNamePasswordValidator
    {
        private readonly IOptionsMonitor<CoreWCFSettings> _options;
        private readonly ILogger<UserNamePasswordValidator> _logger;

        public UserNamePasswordValidator(
            IOptionsMonitor<CoreWCFSettings> options,
            ILogger<UserNamePasswordValidator> logger)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override ValueTask ValidateAsync(string userName, string password)
        {
            if (!IsValidCredentials(userName, password))
            {
                _logger.LogError("Unknown Username {userName} or Incorrect Password.", userName);
                throw new FaultException("Unknown Username or Incorrect Password.");
            }

            return ValueTask.CompletedTask;
        }

        // secure service by number of fail logins from a period of time
        private bool IsValidCredentials(string userName, string password)
        {
            return
                string.Equals(userName, "the-user", StringComparison.InvariantCulture) &&
                string.Equals(password, "P@ssw0rd", StringComparison.InvariantCulture);
        }
    }
}