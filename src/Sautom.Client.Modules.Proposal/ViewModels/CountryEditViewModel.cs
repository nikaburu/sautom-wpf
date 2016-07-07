using System;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.CommandService;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Comunication.Services;

namespace Sautom.Client.Modules.Proposal.ViewModels
{
    public sealed class CountryEditViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public CountryEditViewModel([Dependency("Sautom.Client.Modules.Proposal.Mapper")]IMapper mapper, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;

            SaveCountryCommand = new DelegateCommand<string>(ExecuteSaveCountryCommand);
            AddCityCommand = new DelegateCommand<string>(cityName =>
                                                             {
                                                                 if (!string.IsNullOrWhiteSpace(cityName))
                                                                     Cities.Add(new CityItemDtoOutput { CityName = cityName });
                                                             });
            AddDocumentCommand = new DelegateCommand<string>(docName =>
                                                                 {
                                                                     if (!string.IsNullOrWhiteSpace(docName))
                                                                         EmbassyDocuments.Add(
                                                                             new EmbassyDocumentItemDtoOutput { DocumentName = docName });
                                                                 });

            RemoveCityFromList = new DelegateCommand<string>(cityName => Cities.Remove(Cities.First(rec => rec.CityName == cityName)));
            //RemoveDocFromList = new DelegateCommand<string>(docName => EmbassyDocuments.Remove(EmbassyDocuments.First(rec => rec.DocumentName == docName)));

            QueriesServiceClient = ServiceFactory.Get(eventAggregator).GetQueriesService();
            CommandsServiceClient = ServiceFactory.Get(eventAggregator).GetCommandsService();

            Cities = new ObservableCollection<CityItemDtoOutput>();
            EmbassyDocuments = new ObservableCollection<EmbassyDocumentItemDtoOutput>();
        }

	    #endregion

	    #region INavigationAware implementation

	    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
			// Initial load - Load based on ID passed in
			string id = (string)navigationContext.Parameters["countryId"];
            if (string.IsNullOrWhiteSpace(id)) return;

            CountryEditDtoOutput country = QueriesServiceClient.GetCountryForEdit(Guid.Parse(id));

			Mapper.Map(country, this);

            Cities = new ObservableCollection<CityItemDtoOutput>(country.Cities);
            EmbassyDocuments = new ObservableCollection<EmbassyDocumentItemDtoOutput>(country.EmbassyDocuments);
        }

	    #endregion

	    #region Properties

	    private IMapper Mapper { get; }
	    private IRegionManager RegionManager { get; }
	    private IQueriesService QueriesServiceClient { get; }
	    private ICommandService CommandsServiceClient { get; }

	    #endregion

	    #region Commands

	    public DelegateCommand<string> SaveCountryCommand { get; private set; }
	    public DelegateCommand<string> AddCityCommand { get; private set; }
	    public DelegateCommand<string> AddDocumentCommand { get; private set; }
	    public DelegateCommand<string> RemoveCityFromList { get; private set; }
	    //public DelegateCommand<string> RemoveDocFromList { get; private set; }


	    private void ExecuteSaveCountryCommand(string isSave)
        {
            if (isSave == "true")
            {
                CounrtyEditDtoInput countryData = Mapper.Map<CounrtyEditDtoInput>(this);

                CommandsServiceClient.EditOrAddCountry(countryData);
            }

            RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.CountriesList);
        }

	    #endregion

	    #region Country properties

	    public Guid Id { get; set; }

	    public ObservableCollection<CityItemDtoOutput> Cities { get; set; }
	    public ObservableCollection<EmbassyDocumentItemDtoOutput> EmbassyDocuments { get; set; }

	    private string _countryName;

	    public string CountryName
        {
            get { return _countryName; }
            set
            {
                _countryName = value;
                OnPropertyChanged(() => CountryName);
            }
        }

	    #endregion
    }
}