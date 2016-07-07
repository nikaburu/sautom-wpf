using System;
using System.Threading;
using System.Windows.Threading;
using Prism.Events;
using Prism.Modularity;
using Sautom.Client.Comunication.Commands;
using Sautom.Client.Comunication.Events;
using Sautom.Client.Comunication.Services;
using Sautom.Client.Modules.Authorization.ViewModels;

namespace Sautom.Client.Modules.Authorization.Commands
{
    class ProccessLoginCommand : CommandBase
    {
	    #region Constructors

	    public ProccessLoginCommand(IModuleManager moduleManager, IModuleCatalog moduleCatalog, AuthorizationService authorizationService, EventAggregator eventAggregator, LoginViewModel viewModel)
        {
            _moduleManager = moduleManager;
            _moduleCatalog = moduleCatalog;
            _authorizationService = authorizationService;
            _eventAggregator = eventAggregator;
            _viewModel = viewModel;
        }

	    #endregion

	    #region Overrides of CommandBase

	    protected override void Execute()
        {
            var uiDispather = Dispatcher.CurrentDispatcher;
            new Thread(() =>
            {
	            bool isOk = _authorizationService.ProccessLogin(_viewModel.UserName, _viewModel.Password);
	            uiDispather.BeginInvoke(DispatcherPriority.Normal,
		            (Action)(() =>
		            {
			            if (isOk)
			            {
				            LoadModules();
			            }
			            else
			            {
				            ShowError();
			            }
		            }));
            }).Start();
        }

	    #endregion

	    #region Properties

	    private readonly IModuleManager _moduleManager;
	    private readonly IModuleCatalog _moduleCatalog;
	    private readonly AuthorizationService _authorizationService;
	    private readonly EventAggregator _eventAggregator;
	    private readonly LoginViewModel _viewModel;

	    #endregion

	    #region Private members

	    private void LoadModules()
        {
            foreach (var module in _moduleCatalog.Modules)
            {
                _moduleManager.LoadModule(module.ModuleName);
            }

            _eventAggregator.GetEvent<AuthorizationSuccessEvent>().Publish("success");
        }

	    private void ShowError()
        {
            _viewModel.HasError = true;
        }

	    #endregion
    }
}
