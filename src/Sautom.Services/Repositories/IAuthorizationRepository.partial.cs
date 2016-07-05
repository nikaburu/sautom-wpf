using Sautom.Domain.Entities;

namespace Sautom.Services.Repositories
{
    public partial interface IAuthorizationRepository
    {
	    Authorization GetAuthorization(string name, string password);
    }
}
