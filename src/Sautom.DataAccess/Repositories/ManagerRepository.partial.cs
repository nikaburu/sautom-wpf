using System.Linq;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.Repositories
{
    sealed public partial class ManagerRepository
    {
	    public Manager GetManagerByName(string name)
        {
            return DatabaseContext.Managers.FirstOrDefault(rec => rec.Name == name);
        }
    }
}