using System.Collections.Generic;
using Sautom.DataAccess.Helpers;
using Sautom.Queries;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.DataAccess.Queries
{
    public class CommonFinder : FinderBase, ICommonFinder
    {
	    #region Implementation of ICommonFinder

	    public ICollection<EventNortification> NortificationList()
        {
            return EventAggregator.CheckEvents(DatabaseContext);
        }

	    #endregion
    }
}