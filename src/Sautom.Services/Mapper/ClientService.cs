using AutoMapper;
using Sautom.Domain.Entities;
using Sautom.Services.Dto;

namespace Sautom.Services.Mapper
{
    public class ClientService : Profile
	{
	    public ClientService()
		{
			CreateMap<ContractEditDto, Contract>();
			CreateMap<RateItemDto, Rate>();
			CreateMap<AirlineTicketEditDto, AirlineTicket>();
			CreateMap<ClientEditDto, Client>();
		}
	}
}
