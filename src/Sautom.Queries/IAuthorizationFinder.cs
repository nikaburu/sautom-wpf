using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.Queries
{
    public interface IAuthorizationFinder
    {
	    AunthorizationCredentialsDto GetCredentials(string name, string password);
    }
}
