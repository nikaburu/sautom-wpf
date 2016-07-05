using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.TypeConfiguration
{
    internal sealed class ProposalConfiguration : EntityTypeConfiguration<Proposal>
    {
	    public ProposalConfiguration()
        {
            HasKey(rec => rec.Id);
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.City);
            HasMany(d => d.AvailableHouseTypes).WithMany();
            HasMany(d => d.AvailableIntensities).WithMany();
        }
    }
}
