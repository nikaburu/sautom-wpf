using System;
using AutoMapper;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.FileService;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Comunication.Services;

namespace Sautom.Client.Modules.Client.ViewModels 
{
    public sealed class ContractViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public ContractViewModel([Dependency("Sautom.Client.Modules.Client.Mapper")]IMapper mapper, IRegionManager regionManager, ServiceFactory serviceFactory)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;

            QueriesServiceClient = serviceFactory.GetQueriesService();
            FileServiceClient = serviceFactory.GetFilesService(); 

            ClientFileHelper = new ClientFileHelper(null);

            BackCommand = new DelegateCommand(ExecuteBackCommand);
            EditCommand = new DelegateCommand(ExecuteEditCommand);

            PrintConsultingCommand = new DelegateCommand<string>(ExecutePrintConsultingCommand, str => Id != Guid.Empty);
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

            ContractViewDtoOutput contract = QueriesServiceClient.ContractForView(OrderId);

            Mapper.Map(contract, this);
        }

	    #endregion

	    #region Commands

	    public DelegateCommand EditCommand { get; private set; }
	    public DelegateCommand BackCommand { get; private set; }
	    public DelegateCommand<string> PrintConsultingCommand { get; private set; }

	    private void ExecutePrintConsultingCommand(string type)
        {
            if (!string.IsNullOrEmpty(type) && Id != Guid.Empty)
            {
                FileDownloadDtoOutput fileData = FileServiceClient.ClientContract(Id, type);

                if (fileData != null && fileData.FileData.Length != 0)
                {
                    ClientFileHelper.PrintDocxFile(fileData.FileData);
                }
            }
        }

	    private void ExecuteEditCommand()
        {
            Uri uri = new Uri(PathProvider.ContractEdit +
                new NavigationParameters { 
                { "contractId", Id.ToString() }, 
                { "clientId", ClientId.ToString() }, 
                { "orderId", OrderId.ToString() } },
                UriKind.Relative);
            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

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
	    private IFileService FileServiceClient { get; }

	    private ClientFileHelper ClientFileHelper { get; }

	    #endregion

	    #region ViewModel Properties

	    public Guid ClientId { get; set; }

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
            }
        }

	    private float _consultingSum;

	    public float ConsultingSum
        {
            get { return _consultingSum; }
            set
            {
                _consultingSum = value;
                OnPropertyChanged(() => ConsultingSum);
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

	    public RateItemDtoOutput ConsultingRate { get; set; }

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
            }
        }

	    private float _workshopSum;

	    public float WorkshopSum
        {
            get { return _workshopSum; }
            set
            {
                _workshopSum = value;
                OnPropertyChanged(() => WorkshopSum);
            }
        }

	    private DateTime? _workshopActDate;

	    public DateTime? WorkshopActDate
        {
            get { return _workshopActDate; }
            set
            {
                _workshopActDate = value;
                OnPropertyChanged(() => InvoiceDate);
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

	    public bool IsShowContract { get { return Id != default(Guid); } }

	    public Guid OrderId { get; set; }

	    #endregion
    }
}
