using System;
using System.Collections.Generic;
using System.Linq;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.Repositories
{
    sealed public partial class ProposalRepository
    {
	    public ICollection<HousingType> GetHousingTypes(params Guid[] ids)
        {
            return DatabaseContext.Set<HousingType>().Where(rec => ids.Contains(rec.Id)).ToList();
        }

	    public ICollection<IntensityType> GetIntensityTypes(params Guid[] ids)
        {
            return DatabaseContext.Set<IntensityType>().Where(rec => ids.Contains(rec.Id)).ToList();
        }
    }
}