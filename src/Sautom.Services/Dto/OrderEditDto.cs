using System;
using System.Collections.Generic;

namespace Sautom.Services.Dto
{
    public sealed class OrderEditDto
    {
	    public Guid Id { get; set; }

	    public Guid ProposalId { get; set; }
	    public Guid ManagerId { get; set; }

	    public DateTime StartDate { get; set; }
	    public DateTime EndDate { get; set; }
	    public Guid IntensityId { get; set; }
	    public Guid HouseTypeId { get; set; }

	    public DateTime? EmbassyDate { get; set; }
	    public DateTime? VisaDate { get; set; }
	    public bool? IsEmbassyChecked { get; set; }
	    public List<Guid> EmbassyDocs { get; set; }
    }
}
