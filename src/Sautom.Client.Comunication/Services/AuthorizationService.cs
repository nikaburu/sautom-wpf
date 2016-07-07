using Sautom.Client.Comunication.AuthorizationService;

namespace Sautom.Client.Comunication.Services
{
    public class AuthorizationService
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationService(ServiceFactory serviceFactory)
        {
            _authorizationService = serviceFactory.GetAuthorizationService();
        }
        
        public bool ProccessLogin(string userName, string password)
        {
            var credentials = _authorizationService.GetCredentials(userName, password);
            if (credentials != null)
            {
                UserPrincipal.PrincipalInstance = new UserPrincipal(new UserIdentity(credentials.UserName), credentials.Roles);
                return true;
            }

            return false;
        }

        public bool ChangePassword(string userName, string password, string newPassword)
        {
            return _authorizationService.ChangePassword(userName, password, newPassword);
        }
    }
}
