using System;
using System.Linq;
using AutoMapper;
using Sautom.Domain.Entities;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.DataAccess.Mapper
{
    public class ClientFinder : Profile
	{
	    public ClientFinder()
		{
			CreateMap<Client, ClientEditDto>()
				.ForMember(foo => foo.ParentName, foo => foo.MapFrom(bar => bar.Parent.Name))
				.ForMember(foo => foo.ParentAddress, foo => foo.MapFrom(bar => bar.Parent.Address))
				.ForMember(foo => foo.ParentPhone, foo => foo.MapFrom(bar => bar.Parent.Phone))
				.ForMember(foo => foo.ParentPassportInfo, foo => foo.MapFrom(bar => bar.Parent.PassportInfo));

			CreateMap<Client, ClientViewDto>()
				.ForMember(foo => foo.ParentName, foo => foo.MapFrom(bar => bar.Parent.Name))
				.ForMember(foo => foo.ParentAddress, foo => foo.MapFrom(bar => bar.Parent.Address))
				.ForMember(foo => foo.ParentPhone, foo => foo.MapFrom(bar => bar.Parent.Phone))
				.ForMember(foo => foo.ParentPassportInfo, foo => foo.MapFrom(bar => bar.Parent.PassportInfo))
				.ForMember(foo => foo.Orders, foo => foo.ResolveUsing(bar => bar.Orders.Where(rec => rec.EndDate.Date >= DateTime.Now.Date).ToList()));

			CreateMap<Order, OrderItemDto>()
				.ForMember(foo => foo.SchoolName, foo => foo.MapFrom(bar => bar.Proposal.SchoolName))
				.ForMember(foo => foo.CourseName, foo => foo.MapFrom(bar => bar.Proposal.CourseName))
				.ForMember(foo => foo.IsGroupType, foo => foo.MapFrom(bar => bar.Proposal.IsGroupType))
				.ForMember(foo => foo.ResponsibleManager, foo => foo.MapFrom(bar => bar.ResponsibleManager.DisplayName))
				.ForMember(foo => foo.Intensity, foo => foo.MapFrom(bar => bar.Intensity.IntensityName))
				.ForMember(foo => foo.HouseType, foo => foo.MapFrom(bar => bar.HouseType.HousingName))
				.ForMember(foo => foo.Docs, foo =>
					foo.ResolveUsing(bar => bar.EmbassyDocuments.Select(rec => rec.Id)))
				.ForMember(foo => foo.FullDocsList, foo => foo.Ignore());

			CreateMap<ManagerComment, ManagerCommentItemDto>()
				.ForMember(foo => foo.Manager, foo => foo.ResolveUsing(bar => bar.Manager.DisplayName));

			CreateMap<AirlineTicket, AirlineTicketViewDto>();

			CreateMap<Proposal, ProposalDto>()
				.ForMember(d => d.City, o => o.ResolveUsing(v => v.City.CityName))
				.ForMember(d => d.Country, o => o.ResolveUsing(v => v.City.Country.CountryName))
				.ForMember(d => d.Intensities, o => o.MapFrom(v => v.AvailableIntensities))
				.ForMember(d => d.HouseTypes, o => o.MapFrom(v => v.AvailableHouseTypes));

			CreateMap<IntensityType, GuidStringDto>()
				.ForMember(d => d.Element, o => o.MapFrom(v => v.IntensityName))
				.ForMember(d => d.Id, o => o.MapFrom(v => v.Id));

			CreateMap<HousingType, GuidStringDto>()
				.ForMember(d => d.Element, o => o.MapFrom(v => v.HousingName))
				.ForMember(d => d.Id, o => o.MapFrom(v => v.Id));

			CreateMap<Proposal, ProposalDto>()
				.ForMember(d => d.City, o => o.ResolveUsing(v => v.City.CityName))
				.ForMember(d => d.Country, o => o.ResolveUsing(v => v.City.Country.CountryName))
				.ForMember(d => d.Intensities, o => o.MapFrom(v => v.AvailableIntensities))
				.ForMember(d => d.HouseTypes, o => o.MapFrom(v => v.AvailableHouseTypes));

			CreateMap<IntensityType, GuidStringDto>()
				.ForMember(d => d.Element, o => o.MapFrom(v => v.IntensityName))
				.ForMember(d => d.Id, o => o.MapFrom(v => v.Id));

			CreateMap<HousingType, GuidStringDto>()
				.ForMember(d => d.Element, o => o.MapFrom(v => v.HousingName))
				.ForMember(d => d.Id, o => o.MapFrom(v => v.Id));

			CreateMap<Manager, ManagerDto>();

			CreateMap<AirlineTicket, AirlineTicketViewDto>();
			CreateMap<AirlineTicket, AirlineTicketEditDto>()
				.ForMember(d => d.OrderId, o => o.ResolveUsing(v => v.Order.Id));

			CreateMap<Contract, ContractViewDto>();
			CreateMap<Contract, ContractEditDto>();
		}
	}
}
