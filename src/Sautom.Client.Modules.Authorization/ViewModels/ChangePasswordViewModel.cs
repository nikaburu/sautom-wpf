using System.Windows.Input;
using Prism.Mvvm;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.Commands;
using Sautom.Client.Comunication.Services;
using Sautom.Client.Modules.Authorization.Commands;

namespace Sautom.Client.Modules.Authorization.ViewModels
{
    public class ChangePasswordViewModel : BindableBase
    {
	    #region Constructors

	    public ChangePasswordViewModel(IRegionManager regionManager, AuthorizationService authorizationService)
        {
            ProccessChangePasswordCommand = new ProccessChangePasswordCommand(authorizationService, regionManager, this);
            ToLoginCommand = new SimpleNavigateCommand(regionManager, RegionProvider.MainRegion, PathProvider.Login);
        }

	    #endregion

	    #region Commands

	    public ICommand ProccessChangePasswordCommand { get; set; }
	    public ICommand ToLoginCommand { get; set; }

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

	    private string _newPassword;

	    public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
				OnPropertyChanged(() => NewPassword);
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
