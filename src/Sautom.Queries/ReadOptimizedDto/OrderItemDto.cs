using System;
using System.Collections.Generic;

namespace Sautom.Queries.ReadOptimizedDto
{
    public sealed class OrderItemDto
    {
	    public Guid Id { get; set; }

	    public string SchoolName { get; set; }
	    public string CourseName { get; set; }
	    public bool IsGroupType { get; set; }

	    public string ResponsibleManager { get; set; }

	    public DateTime StartDate { get; set; }
	    public DateTime EndDate { get; set; }
	    public string Intensity { get; set; }
	    public string HouseType { get; set; }

	    public bool IsActive { get; set; }
	    public DateTime? EmbassyDate { get; set; }
	    public DateTime? VisaDate { get; set; }
	    public bool IsEmbassyChecked { get; set; }
	    public List<Guid> Docs { get; set; }
	    public List<GuidStringDto> FullDocsList { get; set; }

	    public AirlineTicketViewDto AirlineTicket { get; set; }
    }
}
