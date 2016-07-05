using System.Linq;
using AutoMapper;
using Sautom.Domain.Entities;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.DataAccess.Mapper
{
    public class ProposalFinder : Profile
	{
	    public ProposalFinder()
		{
			CreateMap<Proposal, ProposalDto>()
				.ForMember(d => d.Country, o => o.MapFrom(v => v.City.Country.CountryName))
				.ForMember(d => d.City, o => o.MapFrom(v => v.City.CityName));

			CreateMap<Proposal, ProposalEditDto>()
				.ForMember(d => d.HouseTypes, o => o.ResolveUsing(v => v.AvailableHouseTypes.Select(rec => rec.Id)))
				.ForMember(d => d.Intensities, o => o.ResolveUsing(v => v.AvailableIntensities.Select(rec => rec.Id)))
				.ForMember(d => d.AvailableHouseTypes, o => o.Ignore())
				.ForMember(d => d.AvailableIntensities, o => o.Ignore());
			CreateMap<Country, CountryItemDto>();

			CreateMap<Country, CountryWitCitiesDto>();
			CreateMap<Country, CountryEditDto>();

			CreateMap<City, CityItemDto>();
			CreateMap<EmbassyDocument, EmbassyDocumentItemDto>();
		}
	}
}
