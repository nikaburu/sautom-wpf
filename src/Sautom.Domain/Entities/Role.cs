using System;

namespace Sautom.Domain.Entities
{
    public class Role : IEntity
    {
	    public string RoleName { get; set; }
	    public Guid Id { get; set; }
    }
}
