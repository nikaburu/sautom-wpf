using System;

namespace Sautom.Queries.ReadOptimizedDto
{
    public sealed class ContractViewDto
    {
	    public Guid Id { get; set; }

	    //consulting section
	    public string ConsultingNumber { get; set; }
	    public DateTime? ConsultingDate { get; set; }
	    public float ConsultingHours { get; set; }
	    public int ConsultingSum { get; set; }
	    public DateTime? ConsultingActDate { get; set; }

	    //workshop section
	    public string WorkshopNumber { get; set; }
	    public DateTime? WorkshopDate { get; set; }
	    public float WorkshopHours { get; set; }
	    public int WorkshopSum { get; set; }
	    public DateTime? WorkshopActDate { get; set; }

	    //invoice section
	    public DateTime? InvoiceDate { get; set; }
	    public int InvoiceSum { get; set; }
    }
}
