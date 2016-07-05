using System.Collections.Generic;
using Sautom.Queries.ReportOptimizedDto;

namespace Sautom.Queries
{
    public interface IReportFinder
    {
	    IList<OrderReportDto> OrderReport(OrderReportDto standard);
    }
}
