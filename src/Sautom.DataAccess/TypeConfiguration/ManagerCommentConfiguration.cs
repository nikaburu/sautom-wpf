using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.TypeConfiguration
{
    internal sealed class ManagerCommentConfiguration : EntityTypeConfiguration<ManagerComment>
    {
	    public ManagerCommentConfiguration()
        {
            HasKey(rec => rec.Id);
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(rec => rec.Client).WithMany(rec => rec.Comments);
            HasRequired(rec => rec.Manager);
        }
    }
}
