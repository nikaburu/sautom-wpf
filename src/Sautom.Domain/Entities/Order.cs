using System;
using System.Collections.Generic;

namespace Sautom.Domain.Entities
{
    public class Order : IEntity
    {
	    public Order()
        {
            EmbassyDocuments = new HashSet<EmbassyDocument>();
        }

	    public bool IsActive => StartDate.Date > DateTime.Now.Date;
	    public DateTime? EmbassyDate { get; set; }
	    public DateTime? VisaDate { get; set; }
	    public bool IsEmbassyChecked { get; set; }

	    public virtual Proposal Proposal { get; set; }
	    public DateTime StartDate { get; set; }
	    public DateTime EndDate { get; set; }
	    public virtual IntensityType Intensity { get; set; }
	    public virtual HousingType HouseType { get; set; }

	    public virtual Manager ResponsibleManager { get; set; }
	    public virtual ICollection<EmbassyDocument> EmbassyDocuments { get; set; }

	    public virtual Client Client { get; set; }
	    public virtual Contract ContractData { get; set; }
	    public virtual AirlineTicket AirlineTicket { get; set; }

	    public Guid Id { get; set; }
    }
}
