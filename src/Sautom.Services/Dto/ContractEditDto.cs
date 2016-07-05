using System;

namespace Sautom.Services.Dto
{
    public sealed class ContractEditDto
    {
	    public Guid Id { get; set; }

	    //consulting section
	    public string ConsultingNumber { get; set; }
	    public DateTime? ConsultingDate { get; set; }
	    public float ConsultingHours { get; set; }
	    public float ConsultingSum { get; set; }
	    public DateTime? ConsultingActDate { get; set; }
	    public RateItemDto ConsultingRate { get; set; }

	    //workshop section
	    public string WorkshopNumber { get; set; }
	    public DateTime? WorkshopDate { get; set; }
	    public float WorkshopHours { get; set; }
	    public float WorkshopSum { get; set; }
	    public DateTime? WorkshopActDate { get; set; }
	    public RateItemDto WorkshopRate { get; set; }

	    //invoice section
	    public DateTime? InvoiceDate { get; set; }
	    public int InvoiceSum { get; set; }

	    public Guid OrderId { get; set; }
    }
}
