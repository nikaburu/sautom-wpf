using System;
using AutoMapper;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.CommandService;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Comunication.Services;
using Sautom.Client.Modules.Client.Controls.ViewModels;

namespace Sautom.Client.Modules.Client.ViewModels 
{
    public sealed class EditOrderAdvancedViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public EditOrderAdvancedViewModel([Dependency("Sautom.Client.Modules.Client.Mapper")]IMapper mapper, IRegionManager regionManager, ServiceFactory serviceFactory)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;

            QueriesServiceClient = serviceFactory.GetQueriesService();
            CommandServiceClient = serviceFactory.GetCommandsService();

            BackCommand = new DelegateCommand(ExecuteBackCommand);

            SaveCommand = new DelegateCommand(ExecuteSaveCommand, () => OrderEditorViewModel.Intensity != null && OrderEditorViewModel.HouseType != null);
        }

	    #endregion

	    #region INavigationAware

	    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            // Initial load - Load based on ID passed in
            string id = (string)navigationContext.Parameters["clientId"];
            string orderId = (string)navigationContext.Parameters["orderId"];
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(orderId)) return;

            ClientId = Guid.Parse(id);
            OrderId = Guid.Parse(orderId);

            CreateOrderInfoDtoOutput data = QueriesServiceClient.GetOrderCreationData();
            OrderEditorViewModel = new OrderEditorViewModel(SaveCommand, data.Proposals, data.ResponsibleManagers);
        }

	    #endregion

	    #region Commands

	    public DelegateCommand BackCommand { get; private set; }
	    public DelegateCommand SaveCommand { get; }

	    private void ExecuteBackCommand()
        {
            RegionManager.RequestNavigate(RegionProvider.MainRegion,
                                          new Uri(PathProvider.ClientDetails + new NavigationParameters { { "clientId", ClientId.ToString() } }, UriKind.Relative));
        }

	    private void ExecuteSaveCommand()
        {
			OrderEditDtoInput orderData = Mapper.Map<OrderEditDtoInput>(OrderEditorViewModel);

            //CommandServiceClient.UpdateOrderForClient(ClientId, orderData);

            ExecuteBackCommand();
        }

	    #endregion

	    #region Properties

	    public IMapper Mapper { get; set; }
	    private IRegionManager RegionManager { get; }
	    private IQueriesService QueriesServiceClient { get; }
	    private ICommandService CommandServiceClient { get; set; }

	    #endregion

	    #region ViewModel Properties

	    public Guid ClientId { get; set; }
	    public Guid OrderId { get; set; }

	    public OrderEditorViewModel OrderEditorViewModel { get; private set; }

	    #endregion
    }
}
