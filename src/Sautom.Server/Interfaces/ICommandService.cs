using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Interfaces
{
    [ServiceContract]
    public interface ICommandService
    {
	    [OperationContract]
        bool ProposalEditOrAdd(ProposalEditDtoInput data);

	    [OperationContract]
        bool AddOrder(Guid clientId, OrderEditDtoInput orderData);

	    [OperationContract]
        bool UpdateOrder(OrderEditDtoInput orderData);

	    [OperationContract]
        bool EditOrAddClient(Guid clientId, ClientEditDtoInput clientData);

	    [OperationContract]
        bool EditOrAddCountry(CounrtyEditDtoInput data);

	    [OperationContract]
        bool EditOrAddRate(RateItemDtoInput data);

	    [OperationContract]
        bool BulkUpdateOrders(Collection<OrderEditDtoInput> orders);

	    [OperationContract]
        bool EditOrAddContract(ContractEditDtoInput contract);

	    [OperationContract]
        bool EditOrAddAirlineTicket(AirlineTicketEditDtoInput airlineTicket);

	    [OperationContract]
        bool AddClientComment(Guid clientId, string comment);
    }
}
