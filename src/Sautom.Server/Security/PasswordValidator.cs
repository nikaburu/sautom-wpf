using System.IdentityModel.Selectors;

namespace Sautom.Server.Security
{
    public class PasswordValidator : UserNamePasswordValidator
    {
	    public override void Validate(string userName, string password)
        { 
            //if (!SystemUser.Users.Any(user => user.Name == userName && user.Password == password))
            //{
            //    throw new SecurityTokenValidationException();
            //}

            Principal.PrincipalInstance = new Principal(userName);
        }
    }
}
