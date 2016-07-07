using System;

namespace Sautom.Client.Modules.Proposal.Models
{
    public sealed class ProposalModel
    {
	    public Guid Id { get; set; }

	    public string City { get; set; }
	    public string Country { get; set; }

	    public string SchoolName { get; set; }
	    public string CourseName { get; set; }

	    public string ProposalType { get; set; }
	    public string CuratorName { get; set; }
	    public DateTime? StartDate { get; set; }
	    public DateTime? EndDate { get; set; }
    }
}
