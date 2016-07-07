using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.FileService;
using Sautom.Client.Comunication.Services;
using Sautom.Client.Modules.Client.Models;

namespace Sautom.Client.Modules.Client.ViewModels
{
    public sealed class ClientFileListViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public ClientFileListViewModel(IRegionManager regionManager, ServiceFactory serviceFactory)
        {
            RegionManager = regionManager;

            FilesServiceClient = serviceFactory.GetFilesService();
            ClientFileHelper = new ClientFileHelper(FilesServiceClient);

            //BackCommand = new DelegateCommand(ExecuteBackCommand);
            DeleteFileCommand = new DelegateCommand<Guid?>(ExecuteDeleteFileCommand);
            UploadFileCommand = new DelegateCommand(ExecuteUploadFileCommand);
            DownloadFileCommand = new DelegateCommand<Guid?>(ExecuteDownloadFileCommand);
        }

	    #endregion

	    #region INavigationAware implementation

	    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // Initial load - Load based on ID passed in
            string id = (string)navigationContext.Parameters["clientId"];
            if (string.IsNullOrWhiteSpace(id)) return;

            Configure(Guid.Parse(id));
        }

	    #endregion

	    public void Configure(Guid clientId)
        {
            ClientId = clientId;

            GuidStringDtoOutput[] filesDto = FilesServiceClient.ClientFileList(clientId);
            Files = new ObservableCollection<GuidStringSelected>(filesDto.Select(rec => new GuidStringSelected {Id = rec.Id, Value = rec.Element}));
        }

	    #region Commands

	    public DelegateCommand BackCommand { get; private set; }
	    public DelegateCommand UploadFileCommand { get; private set; }

	    public DelegateCommand<Guid?> DeleteFileCommand { get; private set; }
	    public DelegateCommand<Guid?> DownloadFileCommand { get; private set; }

	    private void ExecuteDownloadFileCommand(Guid? id)
        {
            if (id != null)
            {
                new Thread(() => ClientFileHelper.DownloadFile(id.Value)).Start();
            }
        }

	    private void ExecuteUploadFileCommand()
        {
            Dispatcher uiDispather = Dispatcher.CurrentDispatcher;
            new Thread(() =>
            {
	            ClientFileHelper.UploadFile(ClientId);
	            uiDispather.BeginInvoke(DispatcherPriority.Normal,
		            (Action)(() => Configure(ClientId)));
            }).Start();
        }

	    private void ExecuteDeleteFileCommand(Guid? id)
        {
            if (id != null)
            {
                //todo apply Prizm Confirmation
                if (MessageBox.Show("Вы уверены что хотите удалить файл клиента?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    FilesServiceClient.RemoveFile(id.Value);
                    Configure(ClientId);
                }
            }
        }

	    //private void ExecuteBackCommand()
	    //{
	    //    var uriQuery = new NavigationParameters { { "clientId", ClientId.ToString() } };
	    //    var uri = new Uri(PathProvider.ClientDetails + uriQuery, UriKind.Relative);
	    //    RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
	    //}

	    #endregion

	    #region Properties

	    private IRegionManager RegionManager { get; set; }
	    private IFileService FilesServiceClient { get; }
	    private ClientFileHelper ClientFileHelper { get; }

	    #endregion

	    #region ViewModel properties

	    public Guid ClientId { get; set; }

	    private ObservableCollection<GuidStringSelected> _files;

	    public ObservableCollection<GuidStringSelected> Files
        {
            get { return _files; }
            set
            {
                _files = value;
                OnPropertyChanged(() => Files);
            }
        }

	    #endregion
    }
}
