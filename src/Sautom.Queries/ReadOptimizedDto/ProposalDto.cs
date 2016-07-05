using System;
using System.Collections.Generic;

namespace Sautom.Queries.ReadOptimizedDto
{
    public sealed class ProposalDto
    {
	    public Guid Id { get; set; }

	    public string Country { get; set; }
	    public string City { get; set; }

	    public string SchoolName { get; set; }
	    public string CourseName { get; set; }

	    public List<GuidStringDto> Intensities { get; set; }
	    public List<GuidStringDto> HouseTypes { get; set; }

	    public bool IsGroupType { get; set; }
	    public DateTime? StartDate { get; set; }
	    public DateTime? EndDate { get; set; }
	    public string CuratorName { get; set; }
    }
}
