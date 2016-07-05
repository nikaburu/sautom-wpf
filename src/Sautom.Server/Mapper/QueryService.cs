using AutoMapper;
using Sautom.Queries.ReadOptimizedDto;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Mapper
{
    //todo T4
    public class QueryService : Profile
	{
	    public QueryService()
		{
			CreateMap<ClientItemDto, ClientItemDtoOutput>();
			CreateMap<OrderItemDto, OrderItemDtoOutput>();
			CreateMap<ClientEditDto, ClientEditDtoOutput>();
			CreateMap<ClientViewDto, ClientViewDtoOutput>();
			CreateMap<CreateOrderInfoDto, CreateOrderInfoDtoOutput>();
			CreateMap<ProposalDto, ProposalDtoOutput>();
			CreateMap<ManagerDto, ManagerDtoOutput>();
			CreateMap<GuidStringDto, GuidStringDtoOutput>();

			CreateMap<ProposalDto, ProposalDtoOutput>();
			CreateMap<ProposalEditDto, ProposalEditDtoOutput>();
			CreateMap<CountryItemDto, CountryItemDtoOutput>();
			CreateMap<CountryEditDto, CountryEditDtoOutput>();
			CreateMap<CityItemDto, CityItemDtoOutput>();
			CreateMap<EmbassyDocumentItemDto, EmbassyDocumentItemDtoOutput>();
			CreateMap<CountryWitCitiesDto, CountryWitCitiesDtoOutput>();
			CreateMap<CityItemDto, CityItemDtoOutput>();

			CreateMap<AirlineTicketViewDto, AirlineTicketViewDtoOutput>();
			CreateMap<AirlineTicketEditDto, AirlineTicketEditDtoOutput>();
			CreateMap<ContractViewDto, ContractViewDtoOutput>();
			CreateMap<ContractEditDto, ContractEditDtoOutput>();
			CreateMap<RateItemDto, RateItemDtoOutput>();

			CreateMap<ManagerCommentItemDto, ManagerCommentItemDtoOutput>();
		}
	}
}
