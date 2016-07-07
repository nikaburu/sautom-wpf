using AutoMapper;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.ReportService;
using Sautom.Client.Modules.Report.Controls.ViewModels;
using Sautom.Client.Modules.Report.Views;

namespace Sautom.Client.Modules.Report
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
			MapperConfiguration config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<OrderQueryBuilderViewModel, OrderReportDtoReport>();
			});
			_container.RegisterInstance("Sautom.Client.Modules.Report.Mapper", config.CreateMapper());

			_container.RegisterType<object, ReportIndex>(PathProvider.ReportIndex);
            _container.RegisterType<object, OrdersReport>(PathProvider.OrdersReport);
            _container.RegisterType<object, ModuleTaskButton>(PathProvider.ReportTaskButton);

            _regionManager.RequestNavigate(RegionProvider.TaskButtonRegion, PathProvider.ReportTaskButton);
        }

	    #endregion
    }
}
