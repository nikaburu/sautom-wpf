using System;

namespace Sautom.Domain.Entities
{
    public class City : IEntity
    {
	    public string CityName { get; set; }

	    public virtual Country Country { get; set; }
	    public Guid Id { get; set; }
    }
}
