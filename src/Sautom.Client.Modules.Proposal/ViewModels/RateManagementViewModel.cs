using System;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.CommandService;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Comunication.Services;

namespace Sautom.Client.Modules.Proposal.ViewModels
{
    public sealed class RateManagementViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public RateManagementViewModel(IRegionManager regionManager, ServiceFactory serviceFactory)
        {
            RegionManager = regionManager;

            QueriesServiceClient = serviceFactory.GetQueriesService();
            CommandServiceClient = serviceFactory.GetCommandsService();

            AddRateCommand = new DelegateCommand(ExecuteAddRateCommand, () => Date.HasValue && RateValue != 0 && Date.Value >= DisplayStartDate);
            BackCommand = new DelegateCommand(() => RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.ProposalIndex));
        }

	    #endregion

	    #region INavigationAware

	    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            RateItems = new ObservableCollection<RateItemDtoOutput>(QueriesServiceClient.GetRatesList().OrderByDescending(rec => rec.Date));
        }

	    #endregion

	    #region Commands

	    public DelegateCommand AddRateCommand { get; }
	    public DelegateCommand BackCommand { get; private set; }

	    private void ExecuteAddRateCommand()
        {
            if (CommandServiceClient.EditOrAddRate(new RateItemDtoInput { Date = Date.GetValueOrDefault(), RateValue = RateValue }))
            {
                RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.RateManagement);
            }
        }

	    #endregion

	    #region Properties

	    private IRegionManager RegionManager { get; }
	    private IQueriesService QueriesServiceClient { get; }
	    private ICommandService CommandServiceClient { get; }

	    #endregion

	    #region ViewModel Properties

	    public DateTime DisplayStartDate
        {
            get
            {
                return RateItems.Select(rec => rec.Date).OrderByDescending(rec => rec).FirstOrDefault().AddDays(1);
            }
        }

	    private DateTime? _date;

	    public DateTime? Date
        {
            get { return _date; }
            set
            {
                _date = value;
				OnPropertyChanged(() => Date);
                AddRateCommand.RaiseCanExecuteChanged();
            }
        }

	    private float _rateValue;

	    public float RateValue
        {
            get { return _rateValue; }
            set
            {
                _rateValue = value;
                OnPropertyChanged(() => RateValue);
                AddRateCommand.RaiseCanExecuteChanged();
            }
        }

	    private ObservableCollection<RateItemDtoOutput> _rateItems;

	    public ObservableCollection<RateItemDtoOutput> RateItems
        {
            get { return _rateItems; }
            set
            {
                _rateItems = value;
                OnPropertyChanged(() => RateItems);
            }
        }

	    #endregion
    }
}
