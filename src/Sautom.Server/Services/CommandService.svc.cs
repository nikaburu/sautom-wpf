using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using AutoMapper;
using Sautom.Server.Interfaces;
using Sautom.Server.Security;
using Sautom.Server.TransportDto;
using Sautom.Services;
using Sautom.Services.Dto;

namespace Sautom.Server.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    sealed public class CommandService : ICommandService
    {
	    #region Constructors

	    public CommandService(IMapper mapper, ClientService clientService, ProposalService proposalService)
        {
		    Mapper = mapper;
		    ClientService = clientService;
            ProposalService = proposalService;
        }

	    #endregion

	    public IMapper Mapper { get; set; }
	    public ClientService ClientService { get; }
	    public ProposalService ProposalService { get; }


	    public bool ProposalEditOrAdd(ProposalEditDtoInput data)
        {
            ProposalEditDto dataMapped = Mapper.Map<ProposalEditDto>(data);

            return ProposalService.EditOrAddProposal(dataMapped).IsValid;
        }

	    public bool AddOrder(Guid clientId, OrderEditDtoInput orderData)
        {
            OrderEditDto input = Mapper.Map<OrderEditDto>(orderData);

            return ClientService.AddOrder(clientId, input).IsValid;
        }

	    public bool UpdateOrder(OrderEditDtoInput orderData)
        {
            OrderEditDto input = Mapper.Map<OrderEditDto>(orderData);

            return ClientService.UpdateOrder(input).IsValid;
        }

	    public bool EditOrAddClient(Guid clientId, ClientEditDtoInput clientData)
        {
            ClientEditDto input = Mapper.Map<ClientEditDto>(clientData);

            return ClientService.EditOrAddClient(clientId, input).IsValid;
        }

	    public bool EditOrAddCountry(CounrtyEditDtoInput data)
        {
            CounrtyEditDto input = Mapper.Map<CounrtyEditDto>(data);

            return ProposalService.EditOrAddCountry(input).IsValid;
        }

	    public bool EditOrAddRate(RateItemDtoInput data)
        {
            RateItemDto input = Mapper.Map<RateItemDto>(data);

            return ProposalService.EditOrAddRate(input).IsValid;
        }

	    public bool BulkUpdateOrders(Collection<OrderEditDtoInput> orders)
        {
            Collection<OrderEditDto> input = Mapper.Map<Collection<OrderEditDto>>(orders);

            return ClientService.BulkUpdateOrders(input).IsValid;
        }

	    public bool EditOrAddContract(ContractEditDtoInput contract)
        {
            ContractEditDto input = Mapper.Map<ContractEditDto>(contract);

            return ClientService.EditOrAddContract(input).IsValid;
        }

	    public bool EditOrAddAirlineTicket(AirlineTicketEditDtoInput airlineTicket)
        {
            AirlineTicketEditDto input = Mapper.Map<AirlineTicketEditDto>(airlineTicket);

            return ClientService.EditOrAddAirlineTicket(input).IsValid;
        }

	    public bool AddClientComment(Guid clientId, string comment)
        {
            return ClientService.AddClientComment(clientId, comment, Principal.PrincipalInstance.Identity.Name).IsValid;
        }
    }
}
