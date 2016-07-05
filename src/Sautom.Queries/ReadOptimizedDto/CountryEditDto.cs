using System;
using System.Collections.Generic;

namespace Sautom.Queries.ReadOptimizedDto
{
    public sealed class CountryEditDto
    {
	    public Guid Id { get; set; }

	    public string CountryName { get; set; }
	    public List<CityItemDto> Cities { get; set; }
	    public List<EmbassyDocumentItemDto> EmbassyDocuments { get; set; }
    }
}
