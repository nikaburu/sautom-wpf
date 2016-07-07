using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using AutoMapper;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Comunication.Services;
using Sautom.Client.Modules.Proposal.Models;

namespace Sautom.Client.Modules.Proposal.ViewModels
{
    public sealed class ProposalIndexViewModel : NavigationAwareNotificationObject, IRegionMemberLifetime
    {
	    #region Constructor

	    public ProposalIndexViewModel([Dependency("Sautom.Client.Modules.Proposal.Mapper")]IMapper mapper, IRegionManager regionManager, ServiceFactory serviceFactory)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;

            EditProposalCommand = new DelegateCommand<string>(ExecuteEditProposalCommand, isCreateNew => isCreateNew == "true" || SelectedItem != null);
            ListCountiresCommand = new DelegateCommand(() => RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.CountriesList));
            RatesCommand = new DelegateCommand(() => RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.RateManagement));

            QueriesServiceClient = serviceFactory.GetQueriesService();
        }

	    #endregion

	    #region Tech properties

	    public IQueriesService QueriesServiceClient { get; set; }

	    #endregion

	    #region Implementation of IRegionMemberLifetime

	    public bool KeepAlive
        {
            get { return true; }
        }

	    #endregion

	    #region Implementation of INavigationAware

	    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            UpdateModelFromService();
        }

	    #endregion

	    #region Private members

	    private void UpdateModelFromService()
        {
            bool? isGroupType = null;
            if (IsGroupFilter != IsIndividualFilter) isGroupType = IsGroupFilter;
            
            Dispatcher uiDispather = Dispatcher.CurrentDispatcher;
            new Thread(() =>
            {
	            List<ProposalDtoOutput> proposals = QueriesServiceClient.GetAllProposals(isGroupType, CountryFilter, SchoolNameFilter, CourseNameFilter).ToList();
	            uiDispather.BeginInvoke(DispatcherPriority.Normal,
		            (Action)(() => Proposals = Mapper.Map(proposals, Proposals)));
            }).Start();
        }

	    #endregion

	    #region Commands

	    public DelegateCommand<string> EditProposalCommand { get; }
	    public DelegateCommand ListCountiresCommand { get; private set; }
	    public DelegateCommand RatesCommand { get; set; }

	    private void ExecuteEditProposalCommand(string isCreateNew)
        {
            NavigationParameters uriQuery = new NavigationParameters();
            if (isCreateNew != "true" && SelectedItem != null)
            {
                uriQuery.Add("proposalId", SelectedItem.Id.ToString());
            }

            Uri uri = new Uri(PathProvider.ProposalEdit + uriQuery, UriKind.Relative);

            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

	    #endregion

	    #region For View properties

	    private IMapper Mapper { get; }
	    private IRegionManager RegionManager { get; }

	    private bool _isIndividualFilter;

	    public bool IsIndividualFilter
        {
            get { return _isIndividualFilter; }
            set
            {
                _isIndividualFilter = value;
                UpdateModelFromService();
            }
        }

	    private bool _isGroupFilter;

	    public bool IsGroupFilter
        {
            get { return _isGroupFilter; }
            set
            {
                _isGroupFilter = value;
                UpdateModelFromService();
            }
        }

	    private string _countryFilter;

	    public string CountryFilter
        {
            get { return _countryFilter; }
            set
            {
                _countryFilter = value;
                UpdateModelFromService();
            }
        }

	    private string _schoolNameFilter;

	    public string SchoolNameFilter
        {
            get { return _schoolNameFilter; }
            set
            {
                _schoolNameFilter = value;
                UpdateModelFromService();
            }
        }

	    private string _courseNameFilter;

	    public string CourseNameFilter
        {
            get { return _courseNameFilter; }
            set
            {
                _courseNameFilter = value;
                UpdateModelFromService();
            }
        }

	    private ProposalModel _selectedItem;

	    public ProposalModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(() => SelectedItem);
                EditProposalCommand.RaiseCanExecuteChanged();
            }
        }

	    private ObservableCollection<ProposalModel> _proposals;

	    public ObservableCollection<ProposalModel> Proposals
        {
            get { return _proposals; }
            set
            {
                _proposals = value;
                OnPropertyChanged(() => Proposals);
            }
        }

	    #endregion
    }
}