using System;
using System.Collections.Generic;

namespace Sautom.Domain.Entities
{
    public class Client : IEntity
    {
	    public Client()
        {
            Orders = new HashSet<Order>();
            Files = new HashSet<ClientFile>();
        }

	    public string PersonalNumber { get; set; }

	    public string FullName => LastName + " " + FirstName + " " + MiddleName;

	    public string NameLat { get; set; }
	    public string FirstName { get; set; }
	    public string LastName { get; set; }
	    public string MiddleName { get; set; }

	    public DateTime? BirthDate { get; set; }
	    public string PassportInfo { get; set; }
	    public string PassportByWhom { get; set; }
	    public DateTime? PassportFromDate { get; set; }
	    public DateTime? PassportByDate { get; set; }

	    public string Address { get; set; }
	    public string PhoneFirst { get; set; }
	    public string PhoneSecond { get; set; }

	    public virtual ICollection<Order> Orders { get; set; }
	    public virtual ICollection<ClientFile> Files { get; set; }
	    public virtual ClientParent Parent { get; set; }

	    public virtual ICollection<ManagerComment> Comments { get; set; }

	    public Guid Id { get; set; }
    }

    public class ClientParent
    {
	    public string Name { get; set; }
	    public string Address { get; set; }
	    public string Phone { get; set; }
	    public string PassportInfo { get; set; }
    }
}
