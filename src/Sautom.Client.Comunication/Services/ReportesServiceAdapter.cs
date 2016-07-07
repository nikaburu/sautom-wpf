using Prism.Events;
using Sautom.Client.Comunication.ReportService;

namespace Sautom.Client.Comunication.Services
{
    internal class ReportesServiceAdapter : BaseServiceAdapter, IReportService
    {
        #region Properties
        private ReportServiceClient ServiceClient { get; set; }
        #endregion

        #region Constructors
        public ReportesServiceAdapter(ReportServiceClient client, IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            ServiceClient = client;
        }
        #endregion

        #region Implementation of IReportService

        public OrderReportDtoReport[] OrderReport(OrderReportDtoReport standard)
        {
            return ExceptionAware(() => ServiceClient.OrderReport(standard), () => new OrderReportDtoReport[0]);
        }

        #endregion
    }
}
