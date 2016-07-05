using System.Collections.Generic;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.Queries
{
    public interface ICommonFinder
    {
	    ICollection<EventNortification> NortificationList();
    }
}
