using System.Linq;
using System.Security.Principal;

namespace Sautom.Client.Comunication.Services
{
    internal class UserPrincipal : IPrincipal
    {
        public static IPrincipal PrincipalInstance { get; set; }

        private readonly IIdentity _identity;
        private readonly string[] _roles;

        public UserPrincipal(IIdentity identity, string[] roles)
        {
            _identity = identity;
            _roles = roles;
        }
        
        #region Implementation of IPrincipal

        bool IPrincipal.IsInRole(string role)
        {
            return _roles.Any(rec => rec == role);
        }

        IIdentity IPrincipal.Identity
        {
            get { return _identity; }
        }

        #endregion
    }
}