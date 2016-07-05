using AutoMapper;
using Sautom.Domain.Entities;
using Sautom.Services.Dto;

namespace Sautom.Services.Mapper
{
    public class ProposalService : Profile
	{
	    public ProposalService()
		{
			CreateMap<ProposalEditDto, Proposal>();
			CreateMap<RateItemDto, Rate> ();
			CreateMap<CounrtyEditDto, Country>()
				.ForMember(d => d.Cities, o => o.Ignore())
				.ForMember(d => d.EmbassyDocuments, o => o.Ignore());
			CreateMap<CounrtyEditDto, Country>();
			CreateMap<CityItemDto, City>();
			CreateMap<EmbassyDocumentItemDto, EmbassyDocument>();
		}
	}
}
