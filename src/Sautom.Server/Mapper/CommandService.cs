using AutoMapper;
using Sautom.Server.TransportDto;
using Sautom.Services.Dto;

namespace Sautom.Server.Mapper
{
    //todo T4
	public class CommandService : Profile
	{
		public CommandService()
		{
			CreateMap<ProposalEditDtoInput, ProposalEditDto>();
			CreateMap<OrderEditDtoInput, OrderEditDto>();
			CreateMap<ClientEditDtoInput, ClientEditDto>();
			CreateMap<CounrtyEditDtoInput, CounrtyEditDto>();
			CreateMap<CityItemDtoInput, CityItemDto>();
			CreateMap<EmbassyDocumentItemDtoInput, EmbassyDocumentItemDto>();
			CreateMap<RateItemDtoInput, RateItemDto>();
			CreateMap<ContractEditDtoInput, ContractEditDto>();
			CreateMap<AirlineTicketEditDtoInput, AirlineTicketEditDto>();
		}
	}
}