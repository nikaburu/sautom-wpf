using System.Collections.Generic;

namespace Sautom.Queries.ReadOptimizedDto
{
    public sealed class CreateOrderInfoDto
    {
	    public List<ProposalDto> Proposals { get; set; }
	    public List<ManagerDto> ResponsibleManagers { get; set; }
    }
}
