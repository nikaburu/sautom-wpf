using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AutoMapper;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.CommandService;
using Sautom.Client.Comunication.FileService;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Comunication.Services;
using Sautom.Client.Modules.Client.Commands;
using Sautom.Client.Modules.Client.Controls.ViewModels;

namespace Sautom.Client.Modules.Client.ViewModels
{
    public sealed class ClientDetailsViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public ClientDetailsViewModel([Dependency("Sautom.Client.Modules.Client.Mapper")]IMapper mapper, IRegionManager regionManager, ServiceFactory serviceFactory, ClientFileListViewModel clientFileListViewModel)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;
            ClinetFileListViewModel = clientFileListViewModel;

            QueriesServiceClient = serviceFactory.GetQueriesService();
            CommandServiceClient = serviceFactory.GetCommandsService();
            FileServiceClient = serviceFactory.GetFilesService();

            ClientFileHelper = new ClientFileHelper(null);

            //todo commands to separate classes
            BackCommand = new SimpleNavigateCommand(regionManager, RegionProvider.MainRegion, PathProvider.ClientIndex);
            
            EditCommand = new DelegateCommand(ExecuteClientEditCommand);
            AddOrderCommand = new DelegateCommand(ExecuteAddOrderCommand);
            AirlineTicketCommand = new DelegateCommand(ExecuteAirlineTicketCommand);
            ContractCommand = new DelegateCommand(ExecuteContractCommand);

            EditOrderAdvancedCommand = new DelegateCommand(ExecuteEditOrderAdvancedCommand);
            
            SelectedOrderViewModel = new OrderViewerViewModel(new PrintOrderDetailsCommand(ClientFileHelper, FileServiceClient));
        }

	    #endregion

	    public ClientFileListViewModel ClinetFileListViewModel { get; set; }

	    #region Commands

	    public ICommand BackCommand { get; private set; }
	    public ICommand EditCommand { get; private set; }
	    public ICommand AddOrderCommand { get; private set; }
	    public ICommand AirlineTicketCommand { get; private set; }
	    public ICommand ContractCommand { get; private set; }
	    public ICommand EditOrderAdvancedCommand { get; private set; }

	    private void ExecuteEditOrderAdvancedCommand()
        {
            NavigationParameters uriQuery = new NavigationParameters { { "clientId", Id.ToString() }, { "orderId", SelectedOrder.Id.ToString() } };
            Uri uri = new Uri(PathProvider.EditOrderAdvanced + uriQuery, UriKind.Relative);
            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

	    private void ExecuteAirlineTicketCommand()
        {
            NavigationParameters uriQuery = new NavigationParameters { { "clientId", Id.ToString() }, { "orderId", SelectedOrder.Id.ToString() } };
            Uri uri = new Uri(PathProvider.AirlineTicketView + uriQuery, UriKind.Relative);
            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);

        }

	    private void ExecuteContractCommand()
        {
            NavigationParameters uriQuery = new NavigationParameters { { "clientId", Id.ToString() }, { "orderId", SelectedOrder.Id.ToString() } };
            Uri uri = new Uri(PathProvider.ContractView + uriQuery, UriKind.Relative);
            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

	    private void ExecuteAddOrderCommand()
        {
            NavigationParameters uriQuery = new NavigationParameters { { "clientId", Id.ToString() } };
            Uri uri = new Uri(PathProvider.ClientAddNewOrder + uriQuery, UriKind.Relative);
            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

	    private void ExecuteClientEditCommand()
        {
            NavigationParameters uriQuery = new NavigationParameters { { "clientId", Id.ToString() } };
            Uri uri = new Uri(PathProvider.ClientEdit + uriQuery, UriKind.Relative);
            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

	    #endregion

	    #region Properties

	    public IMapper Mapper { get; set; }
	    private IRegionManager RegionManager { get; }
	    private IQueriesService QueriesServiceClient { get; }
	    private ICommandService CommandServiceClient { get; }

	    private ClientFileHelper ClientFileHelper { get; }
	    private IFileService FileServiceClient { get; }

	    #endregion

	    #region INavigationAware implementation

	    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            
            // Initial load - Load based on ID passed in
            string id = (string)navigationContext.Parameters["clientId"];
            if (string.IsNullOrWhiteSpace(id)) return;

            ClientViewDtoOutput client = QueriesServiceClient.GetClientForView(Guid.Parse(id));
            Mapper.Map(client, this);

            ClinetFileListViewModel.Configure(client.Id);

            SelectedOrder = Orders.FirstOrDefault(rec => rec.IsActive) ?? Orders.FirstOrDefault();

            Comments = client.Comments.ToList();
        }

	    public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);

            SelectedOrder = SelectedOrder;

            OrderEditDtoInput[] updatedOrders = Orders.Where(rec => rec.IsActive).Select(Mapper.Map<OrderEditDtoInput>).ToArray();
            CommandServiceClient.BulkUpdateOrders(updatedOrders);

            if (!string.IsNullOrWhiteSpace(Comment))
            {
                CommandServiceClient.AddClientComment(Id, Comment);
            }
        }

	    #endregion

	    #region Client properties

	    private string _comment;

	    public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged(() => Comment);
            }
        }

	    private List<ManagerCommentItemDtoOutput> _comments;

	    public List<ManagerCommentItemDtoOutput> Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                OnPropertyChanged(() => Comments);
            }
        }

	    #region Client

	    public Guid Id { get; set; }

	    private string _personalNumber;

	    public string PersonalNumber
        {
            get { return _personalNumber; }
            set
            {
                _personalNumber = value;
                OnPropertyChanged(() => PersonalNumber);
            }
        }

	    private string _nameLat;

	    public string NameLat
        {
            get { return _nameLat; }
            set
            {
                _nameLat = value;
                OnPropertyChanged(() => NameLat);
            }
        }

	    private string _nameRu;

	    public string NameRu
        {
            get { return _nameRu; }
            set
            {
                _nameRu = value;
                OnPropertyChanged(() => NameRu);
            }
        }

	    private DateTime? _birthDate;

	    public DateTime? BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged(() => BirthDate);
            }
        }

	    private string _passportInfo;

	    public string PassportInfo
        {
            get { return _passportInfo; }
            set
            {
                _passportInfo = value;
                OnPropertyChanged(() => PassportInfo);
            }
        }

	    private string _passportByWhom;

	    public string PassportByWhom
        {
            get { return _passportByWhom; }
            set
            {
                _passportByWhom = value;
                OnPropertyChanged(() => PassportByWhom);
            }
        }

	    private DateTime? _passportFromDate;

	    public DateTime? PassportFromDate
        {
            get { return _passportFromDate; }
            set
            {
                _passportFromDate = value;
                OnPropertyChanged(() => PassportFromDate);
            }
        }

	    private DateTime? _passportByDate;

	    public DateTime? PassportByDate
        {
            get { return _passportByDate; }
            set
            {
                _passportByDate = value;
                OnPropertyChanged(() => PassportByDate);
            }
        }

	    private string _address;

	    public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(() => Address);
            }
        }

	    private string _phoneFirst;

	    public string PhoneFirst
        {
            get { return _phoneFirst; }
            set
            {
                _phoneFirst = value;
                OnPropertyChanged(() => PhoneFirst);
            }
        }

	    private string _phoneSecond;

	    public string PhoneSecond
        {
            get { return _phoneSecond; }
            set
            {
                _phoneSecond = value;
                OnPropertyChanged(() => PhoneSecond);
            }
        }

	    //parent section
	    private string _parentName;

	    public string ParentName
        {
            get { return _parentName; }
            set
            {
                _parentName = value;
                OnPropertyChanged(() => ParentName);
            }
        }

	    private string _parentAddress;

	    public string ParentAddress
        {
            get { return _parentAddress; }
            set
            {
                _parentAddress = value;
                OnPropertyChanged(() => ParentAddress);
            }
        }

	    private string _parentPhone;

	    public string ParentPhone
        {
            get { return _parentPhone; }
            set
            {
                _parentPhone = value;
                OnPropertyChanged(() => ParentPhone);
            }
        }

	    private string _parentPassportInfo;

	    public string ParentPassportInfo
        {
            get { return _parentPassportInfo; }
            set
            {
                _parentPassportInfo = value;
                OnPropertyChanged(() => ParentPassportInfo);
            }
        }

	    public bool IsParentSection
        {
            get { return BirthDate.HasValue && Math.Abs(BirthDate.Value.Date.Year - DateTime.Now.Date.Year) < 18; } //todo BL detected
        }

	    #endregion

	    private ObservableCollection<OrderItemDtoOutput> _orders;

	    public ObservableCollection<OrderItemDtoOutput> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged(() => Orders);
            }
        }

	    private OrderItemDtoOutput _selectedOrder;

	    public OrderItemDtoOutput SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(() => SelectedOrder);

                SelectedOrderViewModel.Order = value;
            }
        }

	    private OrderViewerViewModel _selectedOrderViewModel;

	    public OrderViewerViewModel SelectedOrderViewModel
        {
            get { return _selectedOrderViewModel; }
            private set
            {
                _selectedOrderViewModel = value;
                OnPropertyChanged(() => SelectedOrderViewModel);
            }
        }

	    #endregion
    }
}
