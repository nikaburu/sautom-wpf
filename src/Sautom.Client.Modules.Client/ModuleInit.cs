using AutoMapper;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.CommandService;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Modules.Client.Controls.ViewModels;
using Sautom.Client.Modules.Client.Models;
using Sautom.Client.Modules.Client.ViewModels;
using Sautom.Client.Modules.Client.Views;

namespace Sautom.Client.Modules.Client
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
            _container.RegisterType<object, ClientIndex>(PathProvider.ClientIndex);
            _container.RegisterType<object, ClientDetails>(PathProvider.ClientDetails);
            _container.RegisterType<object, ClientEdit>(PathProvider.ClientEdit);
            _container.RegisterType<object, ModuleTaskButton>(PathProvider.ClientTaskButton);
            _container.RegisterType<object, ClientAddNewOrder>(PathProvider.ClientAddNewOrder);
            _container.RegisterType<object, AirlineTicketView>(PathProvider.AirlineTicketView);
            _container.RegisterType<object, ContractView>(PathProvider.ContractView);
            _container.RegisterType<object, ContractEdit>(PathProvider.ContractEdit);
            _container.RegisterType<object, ClientFileList>(PathProvider.ClientFileList);
            _container.RegisterType<object, EditOrderAdvanced>(PathProvider.EditOrderAdvanced);
            
            
            _regionManager.RequestNavigate(RegionProvider.TaskButtonRegion, PathProvider.ClientTaskButton);
            _regionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.ClientIndex);

	        MapperConfiguration config = new MapperConfiguration(cfg =>
	        {
		        cfg.CreateMap<AirlineTicketEditDtoOutput, AirlineTicketViewModel>();
		        cfg.CreateMap<AirlineTicketViewModel, AirlineTicketEditDtoInput>();

		        cfg.CreateMap<OrderEditorViewModel, OrderEditDtoInput>()
			        .ForMember(d => d.IntensityId, o => o.ResolveUsing(v => v.Intensity.Id))
			        .ForMember(d => d.HouseTypeId, o => o.ResolveUsing(v => v.HouseType.Id))
			        .ForMember(d => d.ManagerId, o => o.ResolveUsing(v => v.SelectedManager.Id))
			        .ForMember(d => d.ProposalId, o => o.ResolveUsing(v => v.SelectedProposal.Id));

		        cfg.CreateMap<ContractEditViewModel, ContractEditDtoInput>();
		        cfg.CreateMap<RateItemDtoOutput, RateItemDtoInput>();
		        cfg.CreateMap<ContractEditDtoOutput, ContractEditViewModel>();
		        cfg.CreateMap<ContractViewDtoOutput, ContractViewModel>();

		        cfg.CreateMap<OrderEditorViewModel, OrderEditDtoInput>()
			        .ForMember(d => d.IntensityId, o => o.ResolveUsing(v => v.Intensity.Id))
			        .ForMember(d => d.HouseTypeId, o => o.ResolveUsing(v => v.HouseType.Id))
			        .ForMember(d => d.ManagerId, o => o.ResolveUsing(v => v.SelectedManager.Id))
			        .ForMember(d => d.ProposalId, o => o.ResolveUsing(v => v.SelectedProposal.Id));

		        cfg.CreateMap<ClientViewDtoOutput, ClientDetailsViewModel>()
			        .ForMember(foo => foo.NameRu,
				        foo => foo.ResolveUsing(bar => bar.LastName + " " + bar.FirstName + " " + bar.MiddleName));
		        cfg.CreateMap<OrderItemDtoOutput, OrderEditDtoInput>()
			        .ForMember(d => d.EmbassyDocs, o => o.ResolveUsing(v => v.Docs));

				cfg.CreateMap<ClientEditDtoOutput, ClientInfoEditorViewModel>();
				cfg.CreateMap<ClientItemDtoOutput, ClientItemModel>();

				cfg.CreateMap<ClientInfoEditorViewModel, ClientEditDtoInput>();


			});
			_container.RegisterInstance("Sautom.Client.Modules.Client.Mapper", config.CreateMapper());
		}

	    #endregion
    }
}
