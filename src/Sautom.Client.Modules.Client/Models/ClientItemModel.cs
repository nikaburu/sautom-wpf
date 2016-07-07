using System;

namespace Sautom.Client.Modules.Client.Models
{
    public class ClientItemModel
    {
	    public Guid Id { get; set; }

	    public string PersonalNumber { get; set; }

	    public string NameLat { get; set; }
	    public string NameRu { get; set; }

	    public bool IsActiveClient { get; set; }
	    public string SchoolName { get; set; }
	    public string CourseName { get; set; }
	    public DateTime StartDate { get; set; }

	    public int OrdersCount { get; set; }
	    public bool IsHot { get; set; }
    }
}
