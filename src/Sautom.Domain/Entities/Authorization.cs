using System;
using System.Collections.Generic;

namespace Sautom.Domain.Entities
{
    public class Authorization : IEntity
    {
	    public string Password { get; set; }

	    public virtual ICollection<Role> Roles { get; set; }
	    public virtual Manager Manager { get; set; }
	    public Guid Id { get; set; }
    }
}
