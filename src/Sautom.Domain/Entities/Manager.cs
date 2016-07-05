using System;

namespace Sautom.Domain.Entities
{
    public class Manager : IEntity
    {
	    public string Name { get; set; }

	    public string DisplayName { get; set; }
	    public string DisplayNameBy { get; set; }

	    public DateTime AccreditationDate { get; set; }

	    public string Number { get; set; }

	    public string Position { get; set; }
	    public Guid Id { get; set; }
    }
}
