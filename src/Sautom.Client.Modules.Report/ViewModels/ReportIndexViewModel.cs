using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.Commands;

namespace Sautom.Client.Modules.Report.ViewModels
{
    public sealed class ReportIndexViewModel
    {
	    #region Constructor

	    public ReportIndexViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;

            NavigateToOrdersReportCommand = new SimpleNavigateCommand(regionManager, RegionProvider.MainRegion, PathProvider.OrdersReport);
        }

	    #endregion

	    #region Tech properties

	    private IRegionManager RegionManager { get; set; }

	    #endregion

	    #region Commands

	    public SimpleNavigateCommand NavigateToOrdersReportCommand { get; set; }

	    #endregion

	    #region For View properties

	    #endregion

	    #region Private members

	    #endregion
    }
}