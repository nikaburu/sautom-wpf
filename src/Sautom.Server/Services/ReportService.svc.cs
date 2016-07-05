using System.Collections.Generic;
using System.ServiceModel;
using Sautom.Queries;
using Sautom.Queries.ReportOptimizedDto;
using Sautom.Server.Interfaces;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Services
{
    //todo T4
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    sealed public class ReportService : IReportService
    {
	    #region Constructors

	    public ReportService(IReportFinder reportFinder)
        {
            ReportFinder = reportFinder;
        }

	    #endregion

	    #region Properties

	    public IReportFinder ReportFinder { get; set; }

	    #endregion

	    #region Implementation of IReportService

	    public List<OrderReportDtoReport> OrderReport(OrderReportDtoReport standard)
        {
            OrderReportDto input = AutoMapper.Mapper.Map<OrderReportDto>(standard);
            return AutoMapper.Mapper.Map<List<OrderReportDtoReport>>(ReportFinder.OrderReport(input));
        }

	    #endregion
    }
}
