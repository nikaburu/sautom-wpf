using System.Collections.Generic;
using System.ServiceModel;
using AutoMapper;
using Sautom.Queries;
using Sautom.Server.Interfaces;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    sealed public class CommonService : ICommonService
    {
	    #region Constructors

	    public CommonService(IMapper mapper, ICommonFinder commonFinder)
	    {
		    Mapper = mapper;
		    CommonFinder = commonFinder;
	    }

	    #endregion

	    #region Properties

	    public IMapper Mapper { get; set; }
	    public ICommonFinder CommonFinder { get; set; }

	    #endregion

	    #region Implementation of ICommonService

	    public ICollection<EventNortificationOutput> NortificationList()
        {
            return Mapper.Map<ICollection<EventNortificationOutput>>(CommonFinder.NortificationList());
        }

	    #endregion
    }
}
