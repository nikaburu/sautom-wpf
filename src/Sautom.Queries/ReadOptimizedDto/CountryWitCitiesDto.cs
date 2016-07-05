using System;
using System.Collections.Generic;

namespace Sautom.Queries.ReadOptimizedDto
{
    public sealed class CountryWitCitiesDto
    {
	    public Guid Id { get; set; }

	    public string CountryName { get; set; }

	    public List<CityItemDto> Cities { get; set; }
    }
}
