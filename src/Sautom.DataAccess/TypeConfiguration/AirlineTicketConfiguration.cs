using System.Data.Entity.ModelConfiguration;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.TypeConfiguration
{
    internal sealed class AirlineTicketConfiguration : EntityTypeConfiguration<AirlineTicket>
    {
	    public AirlineTicketConfiguration()
        {
            HasKey(rec => rec.Id);

            HasRequired(d => d.Order).WithOptional(d => d.AirlineTicket);
        }
    }
}
