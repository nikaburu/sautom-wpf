using System;
using System.Collections.Generic;

namespace Sautom.Domain.Entities
{
    public class Country : IEntity
    {
	    public Country()
        {
            Cities = new HashSet<City>();
            EmbassyDocuments = new HashSet<EmbassyDocument>();
        }

	    public string CountryName { get; set; }

	    public virtual ICollection<City> Cities { get; set; }
	    public virtual ICollection<EmbassyDocument> EmbassyDocuments { get; set; }

	    public Guid Id { get; set; }
    }
}
