using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.TypeConfiguration
{
    internal sealed class OrderConfiguration : EntityTypeConfiguration<Order>
    {
	    public OrderConfiguration()
        {
            HasKey(rec => rec.Id);
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(d => d.Proposal);
            HasRequired(d => d.Intensity);

            HasOptional(d => d.AirlineTicket).WithRequired(d => d.Order);
            HasOptional(d => d.ContractData).WithRequired(d => d.Order);

            HasMany(d => d.EmbassyDocuments).WithMany();
        }
    }
}
