using System.Data.Entity.ModelConfiguration;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.TypeConfiguration
{
    internal sealed class ContractConfiguration : EntityTypeConfiguration<Contract>
    {
	    public ContractConfiguration()
        {
            HasKey(rec => rec.Id);
        }
    }
}
