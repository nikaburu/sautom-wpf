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
using Sautom.Client.Modules.Client.Models;

namespace Sautom.Client.Modules.Client.ViewModels
{
    public class ClientIndexViewModel : NavigationAwareNotificationObject, IRegionMemberLifetime
    {
	    #region Constructor

	    public ClientIndexViewModel([Dependency("Sautom.Client.Modules.Client.Mapper")]IMapper mapper, IRegionManager regionManager, ServiceFactory serviceFactory)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;

            ClientDetailsCommand = new DelegateCommand(ExecuteClientDetailsCommand, () => SelectedItem != null);
            AddClientCommand = new DelegateCommand(() => RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.ClientEdit));

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
            Dispatcher uiDispather = Dispatcher.CurrentDispatcher;
            new Thread(() =>
            {
	            List<ClientItemDtoOutput> clients = QueriesServiceClient.GetAllClients(PersonalNumberFilter, NameRuFilter, CourseNameFilter).ToList();
	            uiDispather.BeginInvoke(DispatcherPriority.Normal,
		            (Action)(() => Clients = Mapper.Map(clients, Clients)));
            }).Start();
        }

	    #endregion

	    #region Commands

	    public DelegateCommand ClientDetailsCommand { get; }
	    public DelegateCommand AddClientCommand { get; private set; }

	    private void ExecuteClientDetailsCommand()
        {
            NavigationParameters uriQuery = new NavigationParameters();
            if (SelectedItem != null)
            {
                uriQuery.Add("clientId", SelectedItem.Id.ToString());
            }

            Uri uri = new Uri(PathProvider.ClientDetails + uriQuery, UriKind.Relative);

            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

	    #endregion

	    #region For View properties

	    public IMapper Mapper { get; set; }
	    private IRegionManager RegionManager { get; }

	    private string _personalNumberFilter;

	    public string PersonalNumberFilter
        {
            get { return _personalNumberFilter; }
            set
            {
                _personalNumberFilter = value;
                UpdateModelFromService();
            }
        }

	    private string _nameRuFilter;

	    public string NameRuFilter
        {
            get { return _nameRuFilter; }
            set
            {
                _nameRuFilter = value;
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

	    private ClientItemModel _selectedItem;

	    public ClientItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(() => SelectedItem);
                ClientDetailsCommand.RaiseCanExecuteChanged();
            }
        }

	    private ObservableCollection<ClientItemModel> _clients;

	    public ObservableCollection<ClientItemModel> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged(() => Clients);
            }
        }

	    #endregion
    }
}
