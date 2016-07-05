using System;
using System.Collections.Generic;

namespace Sautom.Services.Dto
{
    public class CounrtyEditDto
    {
	    public Guid Id { get; set; }

	    public string CountryName { get; set; }

	    public List<CityItemDto> Cities { get; set; }
	    public List<EmbassyDocumentItemDto> EmbassyDocuments { get; set; }
    }
}
