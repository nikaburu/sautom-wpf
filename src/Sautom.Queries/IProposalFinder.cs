using System;
using System.Collections.Generic;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.Queries
{
    public interface IProposalFinder
    {
	    ICollection<ProposalDto> GetAll(bool? isGrouptFilter = null, string countryFilter = null, string schoolNameFilter = null, string courseNameFilter = null);
	    ProposalEditDto GetProposalForEdit(Guid proposalId);
	    ICollection<CountryItemDto> GetAllCountries();
	    ICollection<CountryWitCitiesDto> GetAllCountriesWithCities();
	    CountryEditDto GetCountryForEdit(Guid countryId);
	    ICollection<RateItemDto> GetRatesList();

	    ICollection<string> GetCourceNames(string startsWith);
	    ICollection<string> GetSchoolNames(string startsWith, Guid cityId);
    }
}