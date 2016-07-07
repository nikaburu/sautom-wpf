using AutoMapper;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.CommandService;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Modules.Proposal.Models;
using Sautom.Client.Modules.Proposal.Properties;
using Sautom.Client.Modules.Proposal.ViewModels;
using Sautom.Client.Modules.Proposal.Views;

namespace Sautom.Client.Modules.Proposal
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
				cfg.CreateMap<ProposalEditViewModel, ProposalEditDtoInput>()
					.ForMember(d => d.HouseTypes, o => o.Ignore())
					.ForMember(d => d.Intensities, o => o.Ignore());

				cfg.CreateMap<ProposalEditDtoOutput, ProposalEditViewModel>();
				cfg.CreateMap<CountryWitCitiesDtoOutput, CountryModel>();
				cfg.CreateMap<CountryEditViewModel, CounrtyEditDtoInput>();
				cfg.CreateMap<CityItemDtoOutput, CityItemDtoInput>();
				cfg.CreateMap<EmbassyDocumentItemDtoOutput, EmbassyDocumentItemDtoInput>();
				cfg.CreateMap<CountryEditDtoOutput, CountryEditViewModel>();

				cfg.CreateMap<ProposalDtoOutput, ProposalModel>()
				.ForMember(d => d.ProposalType, o => o.ResolveUsing(v => !v.IsGroupType ? Resources.Label_ProposalIndividualType : Resources.Label_ProposalGroupType));
			});
			_container.RegisterInstance("Sautom.Client.Modules.Proposal.Mapper", config.CreateMapper());

			_container.RegisterType<object, ProposalIndex>(PathProvider.ProposalIndex);
            _container.RegisterType<object, ProposalEdit>(PathProvider.ProposalEdit);
            _container.RegisterType<object, CountriesList>(PathProvider.CountriesList);
            _container.RegisterType<object, CountryEdit>(PathProvider.CountryEdit);
            _container.RegisterType<object, ModuleTaskButton>(PathProvider.ProposalTaskButton); 
            _container.RegisterType<object, RateManagement>(PathProvider.RateManagement);

            _regionManager.RequestNavigate(RegionProvider.TaskButtonRegion, PathProvider.ProposalTaskButton);
			//_regionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.ProposalIndex);
		}

		#endregion
	}
}
