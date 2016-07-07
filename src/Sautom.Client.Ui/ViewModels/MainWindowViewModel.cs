using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Sautom.Client.Comunication.Events;

namespace Sautom.Client.Ui.ViewModels
{
    public sealed class MainWindowViewModel : BindableBase
    {
	    private readonly IEventAggregator _eventAggregator;
	    private readonly IRegionManager _regionManager;

	    #region Constructors

	    public MainWindowViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            ExitCommand = new DelegateCommand<object>(obj => Application.Current.Shutdown(), obj => true);

            eventAggregator.GetEvent<NortificationEvent>().Subscribe(NortificationEventRecieved,ThreadOption.UIThread);
            eventAggregator.GetEvent<NortificationEndedEvent>().Subscribe(HideNotification, ThreadOption.UIThread);

            eventAggregator.GetEvent<AuthorizationSuccessEvent>().Subscribe(AuthorizationSuccessEventRecieved, ThreadOption.UIThread);
        }

	    #endregion

	    #region Notifications

	    private bool _isPopup;

	    public bool IsPopup
        {
            get { return _isPopup; }
            set
            {
                _isPopup = value;
                OnPropertyChanged(() => IsPopup);
            }
        }

	    private Nortification _nortification;

	    public Nortification Nortification
        {
            get { return _nortification; }
            private set
            {
                _nortification = value;
				OnPropertyChanged(() => Nortification);
            }
        }

	    private bool IsNotificationActive
        {
            get
            {
                return IsPopup && Nortification != null;
            }
        }

	    private void HideNotification(Guid notificationId)
        {
            if (IsNotificationActive && Nortification.NortificationId == notificationId)
            {
                IsPopup = false;
                Nortification = null;
            }
        }

	    private void AuthorizationSuccessEventRecieved(string obj)
        {
            RibbonCommands = new RibbonCommandViewModel(_regionManager, _eventAggregator);
			OnPropertyChanged(() => RibbonCommands);
        }

	    private void NortificationEventRecieved(Nortification nortification)
        {
            if (IsNotificationActive)
            {
                HideNotification(Nortification.NortificationId);
            }

            Nortification = nortification;
            IsPopup = true;

            if (nortification.CloseAfter != int.MaxValue)
            {
                var uiDispather = Dispatcher.CurrentDispatcher;
                Thread thread = new Thread(() =>
                                               {
                                                   Thread.Sleep(nortification.CloseAfter);

                                                   Action act = () => HideNotification(nortification.NortificationId);
                                                   uiDispather.BeginInvoke(DispatcherPriority.Normal, act);
                                               });
                thread.Start();
                //the same result when uses Timer class
                //_timer = new Timer((obj) => HideNotification(nortification.NortificationId), null, nortification.CloseAfter, Timeout.Infinite);
            }
        }

	    #endregion

	    #region Commands

	    public DelegateCommand<object> ExitCommand { get; private set; }
	    public RibbonCommandViewModel RibbonCommands { get; private set; }

	    #endregion
    }
}