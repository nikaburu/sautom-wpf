using System;
using System.Security.Principal;

namespace Sautom.Server.Security
{
    class Principal : IPrincipal
    {
	    public Principal(string userName)
        {
            Identity = new Identity(userName);
        }

	    public static Principal PrincipalInstance { get; set; }

	    #region Implementation of IPrincipal

	    public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

	    public IIdentity Identity { get; }

	    #endregion
    }

    class Identity : IIdentity
    {
	    public Identity(string name)
        {
            Name = name;
        }

	    #region Implementation of IIdentity

	    public string Name { get; }

	    public string AuthenticationType
        {
            get { throw new NotImplementedException(); }
        }

	    public bool IsAuthenticated
        {
            get { throw new NotImplementedException(); }
        }

	    #endregion
    }
}
