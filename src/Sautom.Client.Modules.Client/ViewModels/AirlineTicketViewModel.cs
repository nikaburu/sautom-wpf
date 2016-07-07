using System;
using AutoMapper;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.CommandService;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Comunication.Services;

namespace Sautom.Client.Modules.Client.ViewModels
{
    public sealed class AirlineTicketViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public AirlineTicketViewModel([Dependency("Sautom.Client.Modules.Client.Mapper")]IMapper mapper, IRegionManager regionManager, ServiceFactory serviceFactory)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;

            QueriesServiceClient = serviceFactory.GetQueriesService();
            CommandServiceClient = serviceFactory.GetCommandsService();

            BackCommand = new DelegateCommand(ExecuteBackCommand);
        }

	    #endregion

	    #region Commands

	    public DelegateCommand BackCommand { get; private set; }

	    private void ExecuteBackCommand()
        {
            Uri uri = new Uri(PathProvider.ClientDetails +
                new NavigationParameters
                    {
                        {
                            "clientId",
                            ClientId.ToString()
                            }
                    },
                UriKind.Relative);
            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

	    #endregion

	    #region Properties

	    public IMapper Mapper { get; set; }
	    private IRegionManager RegionManager { get; }
	    private IQueriesService QueriesServiceClient { get; }
	    private ICommandService CommandServiceClient { get; }

	    #endregion

	    #region ViewModel Properties

	    public Guid ClientId { get; set; }

	    public Guid Id { get; set; }

	    private string _departureCity;

	    public string DepartureCity
        {
            get { return _departureCity; }
            set
            {
                _departureCity = value;
                OnPropertyChanged(() => DepartureCity);
            }
        }

	    private DateTime? _departureDate;

	    public DateTime? DepartureDate
        {
            get { return _departureDate; }
            set
            {
                _departureDate = value;
                OnPropertyChanged(() => DepartureDate);
            }
        }

	    private string _arrivalCity;

	    public string ArrivalCity
        {
            get { return _arrivalCity; }
            set
            {
                _arrivalCity = value;
                OnPropertyChanged(() => ArrivalCity);
            }
        }

	    private DateTime? _arrivalDate;

	    public DateTime? ArrivalDate
        {
            get { return _arrivalDate; }
            set
            {
                _arrivalDate = value;
                OnPropertyChanged(() => ArrivalDate);
            }
        }

	    private DateTime? _bookingDate;

	    public DateTime? BookingDate
        {
            get { return _bookingDate; }
            set
            {
                _bookingDate = value;
                OnPropertyChanged(() => BookingDate);
            }
        }

	    private DateTime? _bookingExpireDate;

	    public DateTime? BookingExpireDate
        {
            get { return _bookingExpireDate; }
            set
            {
                _bookingExpireDate = value;
                OnPropertyChanged(() => BookingExpireDate);
            }
        }

	    private DateTime? _redemptionDate;

	    public DateTime? RedemptionDate
        {
            get { return _redemptionDate; }
            set
            {
                _redemptionDate = value;
                OnPropertyChanged(() => RedemptionDate);
            }
        }

	    public Guid OrderId { get; set; }

	    #endregion

	    #region INavigationAware

	    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            string orderId = (string)navigationContext.Parameters["orderId"];
            string clientId = (string)navigationContext.Parameters["clientId"];
            if (string.IsNullOrWhiteSpace(orderId) || string.IsNullOrWhiteSpace(clientId)) return;

            OrderId = Guid.Parse(orderId);
            ClientId = Guid.Parse(clientId);

            AirlineTicketViewDtoOutput existingTicket = QueriesServiceClient.AirlineTicketForView(OrderId);
            AirlineTicketEditDtoOutput ticketForEdit = QueriesServiceClient.AirlineTicketForEdit(existingTicket == null ? Guid.Empty : existingTicket.Id);

            Mapper.Map(ticketForEdit, this);
        }

	    public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);

			AirlineTicketEditDtoInput ticket =  Mapper.Map<AirlineTicketEditDtoInput>(this);

            CommandServiceClient.EditOrAddAirlineTicket(ticket);
        }

	    #endregion
    }
}
