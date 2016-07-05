using System;

namespace Sautom.Domain.Entities
{
    public class AirlineTicket : IEntity
    {
	    public string DepartureCity { get; set; }
	    public DateTime? DepartureDate { get; set; }

	    public string ArrivalCity { get; set; }
	    public DateTime? ArrivalDate { get; set; }

	    public DateTime? BookingDate { get; set; }
	    public DateTime? BookingExpireDate { get; set; }

	    public DateTime? RedemptionDate { get; set; }
	    public virtual Order Order { get; set; }
	    public Guid Id { get; set; }
    }
}
