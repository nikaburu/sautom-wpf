using System;

namespace Sautom.Queries.ReportOptimizedDto
{
    public sealed class OrderReportDto
    {
	    public string ClientName { get; set; }

	    public string SchoolName { get; set; }
	    public string CourceName { get; set; }

	    public DateTime StartDate { get; set; }
	    public DateTime EndDate { get; set; }
    }
}
