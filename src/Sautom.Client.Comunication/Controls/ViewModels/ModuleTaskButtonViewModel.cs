using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Sautom.Client.Comunication.Events;

namespace Sautom.Client.Comunication.Controls.ViewModels
{
    public class ModuleTaskButtonViewModel : BindableBase
	{
        private readonly string _navigationPath;

        #region Constructor
        public ModuleTaskButtonViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, string navigationPath)
        {
            _navigationPath = navigationPath;
            RegionManager = regionManager;
            EventAggregator = eventAggregator;
            this.Initialize();
        }

        protected IRegionManager RegionManager { get; set; }
        public IEventAggregator EventAggregator { get; set; }

        private void Initialize()
        {
            this.ShowModuleViewCommand = new DelegateCommand(ShowModuleViewCommandExecute);
            this.IsChecked = false;

            EventAggregator.GetEvent<NavigationCompletedEvent>().Subscribe((path) => this.IsChecked = path == _navigationPath);
        }

        #endregion

        #region Command Properties
        public DelegateCommand ShowModuleViewCommand { get; set; }   
        #endregion

        #region Properties

        private bool? _pIsChecked;
        public bool? IsChecked
        {
            get { return _pIsChecked; }

            set
            {
				OnPropertyChanged(() => IsChecked);
                _pIsChecked = value;
				SetProperty(ref this._pIsChecked, value);
            }
        }

        #endregion

        #region Commands
        private void ShowModuleViewCommandExecute()
        {
            RegionManager.RequestNavigate(RegionProvider.MainRegion, _navigationPath, NavigationCompleted);
        }

        private void NavigationCompleted(NavigationResult result)
        {
            // Exit if navigation was not successful
            if (result.Result != true) return;

            // Publish Event
            EventAggregator.GetEvent<NavigationCompletedEvent>()
                .Publish(_navigationPath);
        }

        #endregion
    }
}
