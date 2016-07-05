using System;

namespace Sautom.Domain.Entities
{
    public class IntensityType : IEntity
    {
	    public string IntensityName { get; set; }
	    public Guid Id { get; set; }
    }
}
