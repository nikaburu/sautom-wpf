using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.Commands;
using Sautom.Client.Comunication.Services;
using Sautom.Client.Modules.Authorization.ViewModels;

namespace Sautom.Client.Modules.Authorization.Commands
{
    class ProccessChangePasswordCommand : CommandBase
    {
	    #region Constructors

	    public ProccessChangePasswordCommand(AuthorizationService authorizationService, IRegionManager regionManager, ChangePasswordViewModel changePasswordViewModel)
        {
            _authorizationService = authorizationService;
            _regionManager = regionManager;
            _viewModel = changePasswordViewModel;
        }

	    #endregion

	    #region Overrides of CommandBase

	    protected override void Execute()
        {
            if (_authorizationService.ChangePassword(_viewModel.UserName, _viewModel.Password, _viewModel.NewPassword))
            {
                OnSuccess();
            }
            else
            {
                ShowError();
            }
        }

	    #endregion

	    #region Fields

	    private readonly AuthorizationService _authorizationService;
	    private readonly IRegionManager _regionManager;
	    private readonly ChangePasswordViewModel _viewModel;

	    #endregion

	    #region Private members

	    private void OnSuccess()
        {
            _regionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.Login);
        }

	    private void ShowError()
        {
            _viewModel.HasError = true;
        }

	    #endregion
    }
}
