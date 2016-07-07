using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Regions;
using Sautom.Client.Comunication.ReportService;
using Sautom.Client.Comunication.Services;
using Sautom.Client.Modules.Report.Commands;
using Sautom.Client.Modules.Report.Controls.ViewModels;

namespace Sautom.Client.Modules.Report.ViewModels
{
    public sealed class OrdersReportViewModel : BindableBase
	{
	    #region Constructor

	    public OrdersReportViewModel(IRegionManager regionManager, ServiceFactory serviceFactory)
        {
            RegionManager = regionManager;
            
            BuilderViewModel = new OrderQueryBuilderViewModel(new RequestOrderReportsCommand(this, serviceFactory.GetReportesService()));
        }

	    #endregion

	    #region Tech properties

	    private IRegionManager RegionManager { get; set; }

	    #endregion

	    #region Commands

	    public ICommand UpdateResultsCommand { get; private set; }

	    #endregion

	    #region For View properties

	    public OrderQueryBuilderViewModel BuilderViewModel { get; set; }

	    private ObservableCollection<OrderReportDtoReport> _records;

	    public ObservableCollection<OrderReportDtoReport> Records
        {
            get { return _records; }
            set
            {
                _records = value;
                OnPropertyChanged(() => Records);
            }
        }

	    #endregion

	    #region Private members

	    #endregion
	}
}