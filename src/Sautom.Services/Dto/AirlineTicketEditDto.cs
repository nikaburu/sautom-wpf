using System;

namespace Sautom.Services.Dto
{
    public sealed class AirlineTicketEditDto
    {
	    public Guid Id { get; set; }

	    public string DepartureCity { get; set; }
	    public DateTime? DepartureDate { get; set; }

	    public string ArrivalCity { get; set; }
	    public DateTime? ArrivalDate { get; set; }

	    public DateTime? BookingDate { get; set; }
	    public DateTime? BookingExpireDate { get; set; }

	    public DateTime? RedemptionDate { get; set; }

	    public Guid OrderId { get; set; }
    }
}
