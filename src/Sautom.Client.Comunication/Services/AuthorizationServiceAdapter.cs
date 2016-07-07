using Prism.Events;
using Sautom.Client.Comunication.AuthorizationService;

namespace Sautom.Client.Comunication.Services
{
    internal class AuthorizationServiceAdapter : BaseServiceAdapter, IAuthorizationService
    {
        #region Properties
        private AuthorizationServiceClient ServiceClient { get; set; }
        #endregion

        #region Constructors
        public AuthorizationServiceAdapter(AuthorizationServiceClient client, IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            ServiceClient = client;
        }
        #endregion

        #region Implementation of IAuthorizationService

        public AunthorizationCredentialsDtoOutput GetCredentials(string name, string password)
        {
            return ExceptionAware(() => ServiceClient.GetCredentials(name, password));
        }

        public bool ChangePassword(string name, string password, string newPassword)
        {
            return ExceptionAware(() => new BoolWrapper(ServiceClient.ChangePassword(name, password, newPassword))).Value;
        }

        #endregion
    }

}
