using System;

namespace Sautom.Domain.Entities
{
    public class EmbassyDocument : IEntity
    {
	    public string DocumentName { get; set; }
	    public bool IsArchival { get; set; }

	    public virtual Country Country { get; set; }
	    public Guid Id { get; set; }
    }
}
