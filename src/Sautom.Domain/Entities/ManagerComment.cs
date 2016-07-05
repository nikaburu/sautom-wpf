using System;

namespace Sautom.Domain.Entities
{
    public class ManagerComment : IEntity
    {
	    public DateTime Date { get; set; }
	    public string Comment { get; set; }

	    public virtual Client Client { get; set; }
	    public virtual Manager Manager { get; set; }
	    public Guid Id { get; set; }
    }
}
