using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Modules.EventNortification.Views;

namespace Sautom.Client.Modules.EventNortification
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
            _container.RegisterType<object, EventNotificationList>(PathProvider.EventNotificationList);

            _regionManager.RequestNavigate(RegionProvider.TopLeftRegion, PathProvider.EventNotificationList);
        }

	    #endregion
    }
}
