using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using AutoMapper;
using Sautom.Client.Comunication.Commands;
using Sautom.Client.Comunication.ReportService;
using Sautom.Client.Modules.Report.ViewModels;

namespace Sautom.Client.Modules.Report.Commands
{
    class RequestOrderReportsCommand : CommandBase
    {
	    public RequestOrderReportsCommand(OrdersReportViewModel viewModel, IReportService reportesService)
        {
            ViewModel = viewModel;
            ReportesService = reportesService;
        }

	    private OrdersReportViewModel ViewModel { get; }
	    private IReportService ReportesService { get; }

	    #region Overrides of CommandBase

	    protected override void Execute()
        {
           // Mapper.CreateMap<OrderQueryBuilderViewModel, OrderReportDtoReport>();
            var input = Mapper.Map<OrderReportDtoReport>(ViewModel.BuilderViewModel);
            var uiDispather = Dispatcher.CurrentDispatcher;
            new Thread(() =>
            {
	            var data = ReportesService.OrderReport(input).ToList();

	            uiDispather.BeginInvoke(DispatcherPriority.Normal,
		            (Action)(() => ViewModel.Records = new ObservableCollection<OrderReportDtoReport>(data)));
            }).Start();
        }

	    #endregion
    }
}
