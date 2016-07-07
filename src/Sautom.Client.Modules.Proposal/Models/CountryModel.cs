using System;
using System.Collections.Generic;
using System.Linq;
using Sautom.Client.Comunication.QueriesService;

namespace Sautom.Client.Modules.Proposal.Models
{
    public sealed class CountryModel
    {
	    public Guid Id { get; set; }

	    public string CountryName { get; set; }

	    public List<CityItemDtoOutput> Cities { get; set; }

	    public string CitiesList
        {
            get { return Cities.Select(rec => rec.CityName).Aggregate((sum, item) => sum + ", " + item); }
        }
    }
}
