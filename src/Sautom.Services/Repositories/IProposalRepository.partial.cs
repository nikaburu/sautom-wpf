using System;
using System.Collections.Generic;
using Sautom.Domain.Entities;

namespace Sautom.Services.Repositories
{
    public partial interface IProposalRepository
    {
	    ICollection<HousingType> GetHousingTypes(params Guid[] ids);
	    ICollection<IntensityType> GetIntensityTypes(params Guid[] ids);
    }
}
