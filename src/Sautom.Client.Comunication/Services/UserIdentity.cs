using System;
using System.Security.Principal;

namespace Sautom.Client.Comunication.Services
{
    internal class UserIdentity : IIdentity
    {
        private readonly string _userName;

        public UserIdentity(string userName)
        {
            _userName = userName;
        }

        #region Implementation of IIdentity

        public string Name
        {
            get { return _userName; }
        }

        public string AuthenticationType
        {
            get { throw new NotImplementedException();}
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        #endregion
    }
}