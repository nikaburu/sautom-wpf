using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.Events;

namespace Sautom.Client.Modules.Report.ViewModels
{
    public class ModuleTaskButtonViewModel : BindableBase
    {
	    #region Command Properties

	    public DelegateCommand ShowModuleViewCommand { get; set; }

	    #endregion

	    #region Constructor

	    public ModuleTaskButtonViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            EventAggregator = eventAggregator;
            Initialize();
        }

	    protected IRegionManager RegionManager { get; set; }
	    protected IEventAggregator EventAggregator { get; set; }

	    private void Initialize()
        {
            ShowModuleViewCommand = new DelegateCommand(ShowModuleViewCommandExecute);
            IsChecked = false;

            EventAggregator.GetEvent<NavigationCompletedEvent>().Subscribe(path =>
                                                                               {
                                                                                   IsChecked = path ==
                                                                                                    PathProvider.
                                                                                                        OrdersReport;
                                                                               });
        }

	    #endregion

	    #region Properties

	    private bool? _pIsChecked;

	    public bool? IsChecked
        {
            get { return _pIsChecked; }

            set
            {
                OnPropertyChanged(() => IsChecked);
                _pIsChecked = value;
                OnPropertyChanged(() => IsChecked);
            }
        }

	    #endregion

	    #region Commands

	    private void ShowModuleViewCommandExecute()
        {
            RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.OrdersReport, NavigationCompleted);
        }

	    private void NavigationCompleted(NavigationResult result)
        {
            // Exit if navigation was not successful
            if (result.Result != true) return;

            // Publish Event
            EventAggregator.GetEvent<NavigationCompletedEvent>()
                .Publish(PathProvider.OrdersReport);
        }

	    #endregion

	    #region Private Methods

	    #endregion
    }
}
