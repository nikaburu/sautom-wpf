using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.TypeConfiguration
{
    internal sealed class IntensityTypeConfiguration : EntityTypeConfiguration<IntensityType>
    {
	    public IntensityTypeConfiguration()
        {
            HasKey(rec => rec.Id);
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
