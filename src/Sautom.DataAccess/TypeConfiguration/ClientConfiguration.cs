using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.TypeConfiguration
{
    internal sealed class ClientConfiguration : EntityTypeConfiguration<Client>
    {
	    public ClientConfiguration()
        {
            HasKey(rec => rec.Id);
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Property(d => d.Name).IsRequired();
            //Property(d => d.Description).HasMaxLength(500);
            //Property(d => d.Photo).HasColumnType("image");
        }
    }
}
