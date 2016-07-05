using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using LinqKit;
using Sautom.Domain.Entities;
using Sautom.Queries;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.DataAccess.Queries
{
    public sealed class ProposalFinder : FinderBase, IProposalFinder
    {
	    public ProposalFinder(IMapper mapper)
	    {
		    Mapper = mapper;
	    }

	    #region Dependencies

	    public IMapper Mapper { get; set; }

	    #endregion

	    #region Implementation of IProposalFinder

	    public ICollection<ProposalDto> GetAll(bool? isGrouptFilter = null, string countryFilter = null, string schoolNameFilter = null, string courseNameFilter = null)
        {
            //todo make generic!
            
            Expression<Func<Proposal, bool>> where = PredicateBuilder.True<Proposal>();

            if (isGrouptFilter.HasValue)
            {
                where = where.And(rec => rec.IsGroupType == isGrouptFilter);
            }

            if (!string.IsNullOrWhiteSpace(countryFilter))
            {
                where = where.And(rec => rec.City.Country.CountryName.Contains(countryFilter));
            }

            if (!string.IsNullOrWhiteSpace(schoolNameFilter))
            {
                where = where.And(rec => rec.SchoolName.Contains(schoolNameFilter));
            }

            if (!string.IsNullOrWhiteSpace(courseNameFilter))
            {
                where = where.And(rec => rec.CourseName.Contains(courseNameFilter));
            }

            List<Proposal> proposals = DatabaseContext.Proposals.AsExpandable().Where(where).ToList();
            return Mapper.Map<ICollection<ProposalDto>>(proposals);
        }

	    public ProposalEditDto GetProposalForEdit(Guid proposalId)
        {
            Proposal proposal = DatabaseContext.Proposals.FirstOrDefault(proposl => proposl.Id == proposalId);
            ProposalEditDto dto = new ProposalEditDto();
            if (proposal != null)
            {
                dto = Mapper.Map(proposal, dto);
                dto.CityId = proposal.City.Id;
                dto.CountryId = proposal.City.Country.Id;
            }

            dto.AvailableHouseTypes =
                DatabaseContext.Set<HousingType>().Select(rec => new GuidStringDto { Id = rec.Id, Element = rec.HousingName }).ToList();
            dto.AvailableIntensities =
                DatabaseContext.Set<IntensityType>().Select(rec => new GuidStringDto { Id = rec.Id, Element = rec.IntensityName }).ToList();
            
            return dto;
        }

	    public ICollection<CountryItemDto> GetAllCountries()
        {
			return Mapper.Map<ICollection<CountryItemDto>>(DatabaseContext.Countries.ToList());
        }

	    public ICollection<CountryWitCitiesDto> GetAllCountriesWithCities()
        {
            List<Country> countries = DatabaseContext.Countries.ToList();
            foreach (Country country in countries)
            {
                country.Cities = DatabaseContext.Cities.Where(rec => rec.Country.Id == country.Id).ToList();
            }

            return Mapper.Map<ICollection<CountryWitCitiesDto>>(countries);
        }

	    public CountryEditDto GetCountryForEdit(Guid countryId)
        {
            Country country = DatabaseContext.Countries.Find(countryId);
            country.Cities = DatabaseContext.Cities.Where(rec => rec.Country.Id == country.Id).ToList();
            country.EmbassyDocuments = DatabaseContext.EmbassyDocuments.Where(rec => rec.Country.Id == country.Id).ToList();

            return Mapper.Map<CountryEditDto>(country);
        }

	    public ICollection<RateItemDto> GetRatesList()
        {
            return DatabaseContext.Set<Rate>().Select(rec => new RateItemDto
            {
                                                             Date = rec.Date,
                                                             RateValue = rec.RateValue
                                                         }).ToList();
        }

	    public ICollection<string> GetCourceNames(string startsWith)
        {
            startsWith = startsWith.ToLower();
            return DatabaseContext.Proposals.Select(rec => rec.CourseName).Where(rec => rec.ToLower().StartsWith(startsWith)).ToList();
        }

	    public ICollection<string> GetSchoolNames(string startsWith, Guid cityId)
        {
            startsWith = startsWith.ToLower();
            return DatabaseContext.Proposals.Where(rec => rec.SchoolName.ToLower().StartsWith(startsWith) && rec.City.Id == cityId).Select(rec => rec.SchoolName).ToList();
        }

	    #endregion
    }
}
