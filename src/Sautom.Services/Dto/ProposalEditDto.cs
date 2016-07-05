using System;
using System.Collections.Generic;

namespace Sautom.Services.Dto
{
    public class ProposalEditDto
    {
	    public Guid Id { get; set; }

	    public Guid CityId { get; set; }

	    public string SchoolName { get; set; }
	    public string CourseName { get; set; }

	    public List<Guid> Intensities { get; set; }
	    public List<Guid> HouseTypes { get; set; }

	    public bool IsGroupType { get; set; }
	    public string CuratorName { get; set; }
	    public DateTime? StartDate { get; set; }
	    public DateTime? EndDate { get; set; }
    }
}
