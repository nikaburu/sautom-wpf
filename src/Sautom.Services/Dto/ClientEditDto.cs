using System;

namespace Sautom.Services.Dto
{
    public sealed class ClientEditDto
    {
	    public string PersonalNumber { get; set; }

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

	    //parent section
	    public string ParentName { get; set; }
	    public string ParentAddress { get; set; }
	    public string ParentPhone { get; set; }
	    public string ParentPassportInfo { get; set; }

	    public OrderEditDto OrderInfo { get; set; }
    }
}
