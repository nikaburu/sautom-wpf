using System;
using System.Collections.Generic;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.Queries
{
    public interface IClientFinder
    {
	    ICollection<ClientItemDto> GetAllClients(string personalNumberFilter = null, string nameRuFilter = null, string courseNameFilter = null);
	    ClientEditDto GetClientForEdit(Guid clientId);
	    ClientViewDto GetClientForView(Guid clientId);
	    CreateOrderInfoDto GetOrderCreationData();
	    CreateOrderInfoDto GetOrderEditData(Guid orderId);

	    AirlineTicketViewDto AirlineTicketForView(Guid orderId);
	    AirlineTicketEditDto AirlineTicketForEdit(Guid airlineTickedId);

	    ContractViewDto ContractForView(Guid orderId);
	    ContractEditDto ContractForEdit(Guid contractId);

	    FileDownloadDto ClientContract(Guid clientId, string type);
    }
}
