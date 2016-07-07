using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Modules.Authorization.Views;

namespace Sautom.Client.Modules.Authorization
{
    public class ModuleInit : IModule
    {
	    private readonly IUnityContainer _container;
	    private readonly IRegionManager _regionManager;

	    public ModuleInit(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

	    #region IModule Members

	    public void Initialize()
        {
            _container.RegisterType<object, Login>(PathProvider.Login);
            _container.RegisterType<object, ChangePassword>(PathProvider.ChangePassword);

            _regionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.Login);
        }

	    #endregion
    }
}
