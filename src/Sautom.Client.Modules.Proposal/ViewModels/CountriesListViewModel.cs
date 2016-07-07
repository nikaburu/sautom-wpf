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
    public sealed class CountriesListViewModel : NavigationAwareNotificationObject, IRegionMemberLifetime
    {
	    #region Constructor

	    public CountriesListViewModel([Dependency("Sautom.Client.Modules.Proposal.Mapper")]IMapper mapper, IRegionManager regionManager, ServiceFactory serviceFactory)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;

            EditCountryCommand = new DelegateCommand<string>(ExecuteEditCountryCommand, isCreateNew => isCreateNew == "true" || SelectedItem != null);

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
            Dispatcher uiDispather = Dispatcher.CurrentDispatcher;
            new Thread(() =>
            {
	            List<CountryWitCitiesDtoOutput> countries = QueriesServiceClient.GetAllCountriesWithCities().ToList();

	            uiDispather.BeginInvoke(DispatcherPriority.Normal,
		            (Action)(() => Countries = Mapper.Map(countries, Countries)));
            }).Start();
        }

	    #endregion

	    #region Commands

	    public DelegateCommand<string> EditCountryCommand { get; }

	    private void ExecuteEditCountryCommand(string isCreateNew)
        {
            NavigationParameters uriQuery = new NavigationParameters();
            if (isCreateNew != "true" && SelectedItem != null)
            {
                uriQuery.Add("countryId", SelectedItem.Id.ToString());
            }

            Uri uri = new Uri(PathProvider.CountryEdit + uriQuery, UriKind.Relative);

            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

	    #endregion

	    #region For View properties

	    private IMapper Mapper { get; }
	    private IRegionManager RegionManager { get; }

	    private CountryModel _selectedItem;

	    public CountryModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(() => SelectedItem);
                EditCountryCommand.RaiseCanExecuteChanged();
            }
        }

	    private ObservableCollection<CountryModel> _countries;

	    public ObservableCollection<CountryModel> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                OnPropertyChanged(() => Countries);
            }
        }

	    #endregion
    }
}