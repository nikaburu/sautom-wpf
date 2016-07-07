using System;
using System.Collections.Generic;
using System.Linq;
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
    public sealed class ContractEditViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public ContractEditViewModel([Dependency("Sautom.Client.Modules.Client.Mapper")]IMapper mapper, IRegionManager regionManager, ServiceFactory serviceFactory)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;

            QueriesServiceClient = serviceFactory.GetQueriesService();
            CommandServiceClient = serviceFactory.GetCommandsService();

            BackCommand = new DelegateCommand(ExecuteBackCommand);
            SaveCommand = new DelegateCommand(ExecuteSaveCommand);
        }

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

            string id = (string)navigationContext.Parameters["contractId"];
            Guid idGuid = !string.IsNullOrWhiteSpace(id) ? Guid.Parse(id) : Guid.Empty;

            ContractEditDtoOutput contract = QueriesServiceClient.ContractForEdit(idGuid);

            Mapper.Map(contract, this);
        }

	    #endregion

	    #region Private members

	    private RateItemDtoOutput Rate(DateTime date)
        {
            return Rates.Where(rec => rec.Date.Date <= date.Date).OrderByDescending(rec => rec.Date).FirstOrDefault() ?? new RateItemDtoOutput { Date = DateTime.MinValue, RateValue = 0 };
        }

	    #endregion

	    #region Commands

	    public DelegateCommand SaveCommand { get; private set; }
	    public DelegateCommand BackCommand { get; private set; }

	    private void ExecuteSaveCommand()
        {
            //Mapper.CreateMap<DateTime?, DateTime?>().ForAllMembers(d => d.ResolveUsing(o => o != default(DateTime) ? o : null));
            ContractEditDtoInput contract = Mapper.Map<ContractEditDtoInput>(this);

            CommandServiceClient.EditOrAddContract(contract);

            ExecuteBackCommand();
        }

	    private void ExecuteBackCommand()
        {
            NavigationParameters uriQuery = new NavigationParameters { { "clientId", ClientId.ToString() }, { "orderId", OrderId.ToString() } };
            Uri uri = new Uri(PathProvider.ContractView + uriQuery, UriKind.Relative);
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

	    public Guid Id { get; set; }

	    //consulting section
	    private string _consultingNumber;

	    public string ConsultingNumber
        {
            get { return _consultingNumber; }
            set
            {
                _consultingNumber = value;
                OnPropertyChanged(() => ConsultingNumber);
            }
        }

	    private DateTime? _consultingDate;

	    public DateTime? ConsultingDate
        {
            get { return _consultingDate; }
            set
            {
                _consultingDate = value;
                OnPropertyChanged(() => ConsultingDate);
                OnPropertyChanged(() => ConsultingSum);
            }
        }

	    private float _consultingHours;

	    public float ConsultingHours
        {
            get { return _consultingHours; }
            set
            {
                _consultingHours = value;
                OnPropertyChanged(() => ConsultingHours);
                OnPropertyChanged(() => ConsultingSum);
            }
        }

	    public float ConsultingSum
        {
            get
            {
                if (_consultingDate.HasValue)
                {
                    ConsultingRate = Rate(_consultingDate.Value);

                    return _consultingHours * ConsultingRate.RateValue;
                }

                return 0;
            }
        }

	    private DateTime? _consultingActDate;

	    public DateTime? ConsultingActDate
        {
            get { return _consultingActDate; }
            set
            {
                _consultingActDate = value;
                OnPropertyChanged(() => ConsultingActDate);
            }
        }

	    private RateItemDtoOutput _consultingRate;

	    public RateItemDtoOutput ConsultingRate
        {
            get
            {
                return _consultingRate;
            }
            set
            {
                _consultingRate = value;
                OnPropertyChanged(() => ConsultingRate);
            }
        }

	    //workshop section
	    private string _workshopNumber;

	    public string WorkshopNumber
        {
            get { return _workshopNumber; }
            set
            {
                _workshopNumber = value;
                OnPropertyChanged(() => WorkshopNumber);
            }
        }

	    private DateTime? _workshopDate;

	    public DateTime? WorkshopDate
        {
            get { return _workshopDate; }
            set
            {
                _workshopDate = value;
                OnPropertyChanged(() => WorkshopDate);
                OnPropertyChanged(() => WorkshopSum);
            }
        }

	    private float _workshopHours;

	    public float WorkshopHours
        {
            get { return _workshopHours; }
            set
            {
                _workshopHours = value;
                OnPropertyChanged(() => WorkshopHours);
                OnPropertyChanged(() => WorkshopSum);
            }
        }

	    public float WorkshopSum
        {
            get
            {
                if (_workshopDate.HasValue)
                {
                    WorkshopRate = Rate(_workshopDate.Value);

                    return _workshopHours * WorkshopRate.RateValue;
                }

                return 0;
            }
        }

	    private DateTime? _workshopActDate;

	    public DateTime? WorkshopActDate
        {
            get { return _workshopActDate; }
            set
            {
                _workshopActDate = value;
                OnPropertyChanged(() => WorkshopActDate);
            }
        }

	    public RateItemDtoOutput WorkshopRate { get; set; }

	    //invoice section
	    private DateTime? _invoiceDate;

	    public DateTime? InvoiceDate
        {
            get { return _invoiceDate; }
            set
            {
                _invoiceDate = value;
                OnPropertyChanged(() => InvoiceDate);
            }
        }

	    private int _invoiceSum;

	    public int InvoiceSum
        {
            get { return _invoiceSum; }
            set
            {
                _invoiceSum = value;
                OnPropertyChanged(() => InvoiceSum);
            }
        }

	    public List<RateItemDtoOutput> Rates { get; set; }

	    public Guid OrderId { get; set; }
	    public Guid ClientId { get; set; }

	    #endregion
    }
}
