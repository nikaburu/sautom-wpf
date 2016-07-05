using System;
using System.Collections.Generic;

namespace Sautom.Domain.Entities
{
    public class Proposal : IEntity
    {
	    public Proposal()
        {
            AvailableIntensities = new HashSet<IntensityType>();
            AvailableHouseTypes = new HashSet<HousingType>();
        }

	    public virtual City City { get; set; }

	    public string SchoolName { get; set; }
	    public string CourseName { get; set; }

	    public virtual ICollection<IntensityType> AvailableIntensities { get; set; }
	    public virtual ICollection<HousingType> AvailableHouseTypes { get; set; }

	    public bool IsGroupType { get; set; }
	    public string CuratorName { get; set; }
	    public DateTime? StartDate { get; set; }
	    public DateTime? EndDate { get; set; }

	    public Guid Id { get; set; }
    }
}
