using System.Linq;
using Sautom.Domain.Entities;
using Sautom.Queries;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.DataAccess.Queries
{
    public sealed class AuthorizationFinder : FinderBase, IAuthorizationFinder
    {
	    #region Implementation of IAuthorizationFinder

	    public AunthorizationCredentialsDto GetCredentials(string name, string password)
        {
            Authorization auth = DatabaseContext.Authorizations.FirstOrDefault(rec => rec.Password == password && rec.Manager.Name == name);

            return auth == null ? null : new AunthorizationCredentialsDto
            {
                                                 Id = auth.Id,
                                                 Roles = auth.Roles.Select(rec => rec.RoleName).ToList(),
                                                 UserDisplayName = auth.Manager.DisplayName,
                                                 UserName = auth.Manager.Name
                                             };
        }

	    #endregion
    }
}
