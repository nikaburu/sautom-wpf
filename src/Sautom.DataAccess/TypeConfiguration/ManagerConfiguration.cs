using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.TypeConfiguration
{
    internal sealed class ManagerConfiguration : EntityTypeConfiguration<Manager>
    {
	    public ManagerConfiguration()
        {
            HasKey(rec => rec.Id);
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(l => l.Name).IsRequired().HasMaxLength(200);
            //Property(l => l.MilesFromNearestAirport).HasPrecision(8, 1);
            //Property(l => l.Owner).IsUnicode(false);
        }
    }
}
