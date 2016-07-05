using Sautom.Domain.Entities;

namespace Sautom.Services.Repositories
{
    public partial interface IManagerRepository
    {
	    Manager GetManagerByName(string name);
    }
}
