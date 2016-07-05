using System.Linq;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.Repositories
{
    sealed public partial class AuthorizationRepository
    {
	    public Authorization GetAuthorization(string name, string password)
        {
            return DatabaseContext.Authorizations.FirstOrDefault(rec => rec.Manager.Name == name && rec.Password == password);
        }
    }
}