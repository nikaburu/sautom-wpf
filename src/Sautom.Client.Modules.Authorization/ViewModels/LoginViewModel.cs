using System.Windows.Input;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.Commands;
using Sautom.Client.Comunication.Services;
using Sautom.Client.Modules.Authorization.Commands;

namespace Sautom.Client.Modules.Authorization.ViewModels
{
    public class LoginViewModel : BindableBase
    {
	    private readonly EventAggregator _eventAggregator;

	    #region Constructors

	    public LoginViewModel(IRegionManager regionManager, IModuleManager moduleManager, IModuleCatalog moduleCatalog, AuthorizationService authorizationService, EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            ProccessLoginCommand = new ProccessLoginCommand(moduleManager, moduleCatalog, authorizationService, _eventAggregator, this);
            ToChangePasswordCommand = new SimpleNavigateCommand(regionManager, RegionProvider.MainRegion, PathProvider.ChangePassword);

		    UserName = "Pavlova";
		    Password = "1234";
        }

	    #endregion

	    #region Commands

	    public ICommand ProccessLoginCommand { get; set; }
	    public ICommand ToChangePasswordCommand { get; set; }

	    #endregion

	    #region View model properties

	    private string _userName;

	    public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
				OnPropertyChanged(() => UserName);
            }
        }

	    private string _password;

	    public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
				OnPropertyChanged(() => Password);
            }
        }

	    private bool _hasError;

	    public bool HasError
        {
            get { return _hasError; }
            set 
            {
                _hasError = value;
				OnPropertyChanged(() => HasError);
            }
        }

	    #endregion
    }
}
