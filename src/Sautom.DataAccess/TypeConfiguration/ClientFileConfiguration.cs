using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.TypeConfiguration
{
    internal sealed class ClientFileConfiguration : EntityTypeConfiguration<ClientFile>
    {
	    public ClientFileConfiguration()
        {
            HasKey(rec => rec.Id);
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(b => b.Client).WithMany(i => i.Files);
        }
    }
}
