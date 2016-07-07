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
    public sealed class ClientEditViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public ClientEditViewModel([Dependency("Sautom.Client.Modules.Client.Mapper")]IMapper mapper, IRegionManager regionManager, ServiceFactory serviceFactory)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;

            QueriesServiceClient = serviceFactory.GetQueriesService();
            CommandServiceClient = serviceFactory.GetCommandsService();

            BackCommand = new DelegateCommand(ExecuteBackCommand);
            SaveCommand = new DelegateCommand(ExecuteSaveCommand);
        }

	    #endregion

	    #region INavigationAware implementation

	    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // Not refresh every time the view is loaded
            if (ClientInfoEditorViewModel != null) return;

            // Initial load - Load based on ID passed in
            string id = (string)navigationContext.Parameters["clientId"];

            ClientEditDtoOutput client = QueriesServiceClient.GetClientForEdit(!string.IsNullOrWhiteSpace(id) ? Guid.Parse(id) : Guid.Empty);
            ClientInfoEditorViewModel = Mapper.Map<ClientInfoEditorViewModel>(client) ?? new ClientInfoEditorViewModel { BirthDate = DateTime.Now.AddYears(-18) };
        }

	    #endregion

	    #region Commands

	    public DelegateCommand BackCommand { get; private set; }
	    public DelegateCommand SaveCommand { get; private set; }

	    private void ExecuteSaveCommand()
        {
            //todo make it pretty
            bool isError = false;
            if (string.IsNullOrWhiteSpace(ClientInfoEditorViewModel.FirstName))
            {
                isError = true;
                ClientInfoEditorViewModel.IsFirstNameError = true;
            }
            else
            {
                ClientInfoEditorViewModel.IsFirstNameError = false;
            }

            if (string.IsNullOrWhiteSpace(ClientInfoEditorViewModel.MiddleName))
            {
                isError = true;
                ClientInfoEditorViewModel.IsMiddleNameError = true;
            }
            else
            {
                ClientInfoEditorViewModel.IsMiddleNameError = false;
            }

            if (string.IsNullOrWhiteSpace(ClientInfoEditorViewModel.LastName))
            {
                isError = true;
                ClientInfoEditorViewModel.IsLastNameError = true;
            }

            else
            {
                ClientInfoEditorViewModel.IsLastNameError = false;
            }

            if (isError)
            {
                return;
            }
			
            ClientEditDtoInput data = Mapper.Map<ClientEditDtoInput>(ClientInfoEditorViewModel);

            CommandServiceClient.EditOrAddClient(ClientInfoEditorViewModel.Id, data);

            ExecuteBackCommand();
        }

	    private void ExecuteBackCommand()
        {
            Uri uri;
            if (ClientInfoEditorViewModel.Id == Guid.Empty)
            {
                uri = new Uri(PathProvider.ClientIndex, UriKind.Relative);
            }
            else
            {
                NavigationParameters uriQuery = new NavigationParameters { { "clientId", ClientInfoEditorViewModel.Id.ToString() } };
                uri = new Uri(PathProvider.ClientDetails + uriQuery, UriKind.Relative);
            }


            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

	    #endregion

	    #region Properties

	    public IMapper Mapper { get; set; }
	    private IRegionManager RegionManager { get; }
	    private IQueriesService QueriesServiceClient { get; }
	    private ICommandService CommandServiceClient { get; }

	    public ClientInfoEditorViewModel ClientInfoEditorViewModel { get; set; }

	    #endregion
    }
}
