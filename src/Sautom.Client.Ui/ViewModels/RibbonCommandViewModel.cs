using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.Events;

namespace Sautom.Client.Ui.ViewModels
{
    public class RibbonCommandViewModel
    {
	    public RibbonCommandViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            EventAggregator = eventAggregator;

            InitializeCommands();
        }

	    private IRegionManager RegionManager { get; }
	    private IEventAggregator EventAggregator { get; }

	    private void InitializeCommands()
        {
            ProposalsListCommand = new DelegateCommand(() => RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.ProposalIndex, NavigationProposalsCompleted));
            CountriesListCommand = new DelegateCommand(() => RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.CountriesList, NavigationProposalsCompleted));
            RatesListCommand = new DelegateCommand(() => RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.RateManagement, NavigationProposalsCompleted));

            ClientsListCommand = new DelegateCommand(() => RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.ClientIndex, NavigationClientsCompleted));
            AddNewClientCommand = new DelegateCommand(() => RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.ClientEdit, NavigationClientsCompleted));
        }

	    #region Commands

	    public DelegateCommand ProposalsListCommand { get; private set; }
	    public DelegateCommand CountriesListCommand { get; private set; }
	    public DelegateCommand RatesListCommand { get; private set; }

	    public DelegateCommand ClientsListCommand { get; private set; }
	    public DelegateCommand AddNewClientCommand { get; private set; }

	    private void NavigationProposalsCompleted(NavigationResult result)
        {
            // Exit if navigation was not successful
            if (result.Result != true) return;

            // Publish Event
            EventAggregator.GetEvent<NavigationCompletedEvent>()
                .Publish(PathProvider.ProposalIndex);
        }

	    private void NavigationClientsCompleted(NavigationResult result)
        {
            // Exit if navigation was not successful
            if (result.Result != true) return;

            // Publish Event
            EventAggregator.GetEvent<NavigationCompletedEvent>()
                .Publish(PathProvider.ClientIndex);
        }

	    #endregion
    }
}
