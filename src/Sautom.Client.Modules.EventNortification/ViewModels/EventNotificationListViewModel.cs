using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.CommonService;
using Sautom.Client.Comunication.Services;
using Sautom.Client.Modules.EventNortification.Helpers;
using Sautom.Client.Modules.EventNortification.Model;

namespace Sautom.Client.Modules.EventNortification.ViewModels
{
    public sealed class EventNotificationListViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public EventNotificationListViewModel(IRegionManager regionManager, ServiceFactory serviceFactory)
        {
            RegionManager = regionManager;

            CommonService = serviceFactory.GetCommonService();

            GoToEventCommand = new DelegateCommand<Guid?>(ExecuteGoToEventCommand);
        }

	    #endregion

	    #region INavigationAware implementation

	    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var uiDispather = Dispatcher.CurrentDispatcher;
             
            var updateThread = new Thread(() =>
                                           {
                                               while (true)
                                               {
                                                   uiDispather.BeginInvoke(DispatcherPriority.Background,
                                                        (Action)UpdateNotifications);
                                                   //todo make interval longer
                                                   Thread.Sleep(new TimeSpan(0, 1, 0));
                                               }
                                           });

            updateThread.IsBackground = true;
            updateThread.Start();
        }

	    #endregion

	    #region Privates

	    private void UpdateNotifications()
        {
            var uiDispather = Dispatcher.CurrentDispatcher;
            new Thread(() =>
                           {
                               var notifications = CommonService.NortificationList();
                               uiDispather.BeginInvoke(DispatcherPriority.Background,
                                                       (Action)(() => Notifications = new ObservableCollection<EventNotificationItem>(EventNotificationFormatter.Process(notifications))));
                           }).Start();
        }

	    #endregion

	    #region Commands

	    public DelegateCommand<Guid?> GoToEventCommand { get; private set; }

	    private void ExecuteGoToEventCommand(Guid? id)
        {
            if (!id.HasValue) return;

            Uri uri = Notifications.First(rec => rec.Id == id).ActionUri;
            RegionManager.RequestNavigate(RegionProvider.MainRegion, uri);
        }

	    #endregion

	    #region Properties

	    private IRegionManager RegionManager { get; }
	    private ICommonService CommonService { get; }

	    #endregion

	    #region ViewModel properties

	    private ObservableCollection<EventNotificationItem> _notifications;

	    public ObservableCollection<EventNotificationItem> Notifications
        {
            get { return _notifications; }
            set
            {
                _notifications = value;
                OnPropertyChanged(() => Notifications);
            }
        }

	    #endregion
    }
}
