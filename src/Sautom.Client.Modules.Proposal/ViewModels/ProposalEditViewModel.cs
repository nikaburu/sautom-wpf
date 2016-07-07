using System;
using System.Collections.Generic;
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
using Sautom.Client.Modules.Proposal.Controls;
using Sautom.Client.Modules.Proposal.Models;

namespace Sautom.Client.Modules.Proposal.ViewModels
{
    public sealed class ProposalEditViewModel : NavigationAwareNotificationObject
    {
	    #region Constructor

	    public ProposalEditViewModel([Dependency("Sautom.Client.Modules.Proposal.Mapper")]IMapper mapper, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
	        Mapper = mapper;
	        RegionManager = regionManager;

            SaveProposalCommand = new DelegateCommand<string>(ExecuteSaveProposalCommand, param => true);
            CourcesComboChanged = args => ComboChangedActivated(args, GetCourseNameVariants);
            SchoolesComboChanged = args => ComboChangedActivated(args, GetSchoolNameVariants);
            
            QueriesServiceClient = ServiceFactory.Get(eventAggregator).GetQueriesService();
            CommandsServiceClient = ServiceFactory.Get(eventAggregator).GetCommandsService();
        }

	    #endregion

	    #region INavigationAware implementation

	    public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            Countries = new ObservableCollection<CountryWitCitiesDtoOutput>(QueriesServiceClient.GetAllCountriesWithCities());
            SelectedCountry = Countries.First();
            SelectedCity = SelectedCountry.Cities.First();

            // Initial load - Load based on ID passed in
            string id = (string)navigationContext.Parameters["proposalId"] ?? Guid.Empty.ToString();

            ProposalEditDtoOutput proposal = QueriesServiceClient.GetProposalForEdit(Guid.Parse(id));
            if (proposal.Id != Guid.Empty)
            {
				Mapper.Map(proposal, this);

                SelectedCountry = Countries.First(rec => rec.Id == proposal.CountryId);
                SelectedCity = SelectedCountry.Cities.First(rec => rec.Id == proposal.CityId);
            }

            IntensivityList = new ObservableCollection<GuidStringSelected>(proposal.AvailableIntensities.Select(
                    rec => new GuidStringSelected { Id = rec.Id, Value = rec.Element, IsSelected = proposal.Intensities.Any(i => i == rec.Id), SelectionGroup = "IntensivityList" }));

            HouseTypeList = new ObservableCollection<GuidStringSelected>(proposal.AvailableHouseTypes.Select(
                    rec => new GuidStringSelected { Id = rec.Id, Value = rec.Element, IsSelected = proposal.HouseTypes.Any(i => i == rec.Id), SelectionGroup = "HouseTypeList" }));
        }

	    #endregion

	    #region Properties

	    private IMapper Mapper { get; }
	    private IRegionManager RegionManager { get; }
	    private IQueriesService QueriesServiceClient { get; }
	    private ICommandService CommandsServiceClient { get; }

	    #endregion

	    #region Commands

	    public DelegateCommand<string> SaveProposalCommand { get; private set; }
	    public Action<AutoComplete.AutoCompleteArgs> CourcesComboChanged { get; private set; }
	    public Action<AutoComplete.AutoCompleteArgs> SchoolesComboChanged { get; private set; }

	    private static void ComboChangedActivated(AutoComplete.AutoCompleteArgs args, Func<string, IEnumerable<string>> dataGetAction)
        {
            if (string.IsNullOrEmpty(args.Pattern) || args.Pattern.Length < 3)
                args.CancelBinding = true;
            else
                args.DataSource = dataGetAction(args.Pattern);
        }

	    private IEnumerable<string> _courceNames;
	    private string _courceNameLastLoadedPattern;

	    private IEnumerable<string> GetCourseNameVariants(string pattern)
        {
            if (_courceNames == null || !pattern.StartsWith(_courceNameLastLoadedPattern))
            {
                _courceNames = QueriesServiceClient.GetCourceNames(pattern);
                _courceNameLastLoadedPattern = pattern;
            }

            return _courceNames.Where(rec => rec.ToLower().StartsWith(pattern.ToLower()));
        }

	    private IEnumerable<string> _schoolNames;
	    private string _schoolNameLastLoadedPattern;
	    private Guid _schoolNameLastLoadedCity;

	    private IEnumerable<string> GetSchoolNameVariants(string pattern)
        {
            if (_schoolNames == null || !pattern.StartsWith(_schoolNameLastLoadedPattern) || SelectedCity.Id != _schoolNameLastLoadedCity)
            {
                _schoolNames = QueriesServiceClient.GetSchoolNames(pattern, SelectedCity.Id);
                _schoolNameLastLoadedPattern = pattern;
                _schoolNameLastLoadedCity = SelectedCity.Id;
            }

            return _schoolNames.Where(rec => rec.ToLower().StartsWith(pattern.ToLower()));
        }

	    private void ExecuteSaveProposalCommand(string isSave)
        {
            if (isSave == "true")
            {
                ProposalEditDtoInput proposalData = Mapper.Map<ProposalEditDtoInput>(this);
                proposalData.CityId = SelectedCity.Id;
                proposalData.Intensities = IntensivityList.Where(rec => rec.IsSelected).Select(rec => rec.Id).ToArray();
                proposalData.HouseTypes = HouseTypeList.Where(rec => rec.IsSelected).Select(rec => rec.Id).ToArray();
                
                if (!IsGroupType)
                {
                    proposalData.EndDate = null;
                    proposalData.StartDate = null;
                    proposalData.CuratorName = null;
                }

                CommandsServiceClient.ProposalEditOrAdd(proposalData);
            }

            RegionManager.RequestNavigate(RegionProvider.MainRegion, PathProvider.ProposalIndex);
        }

	    #endregion

	    #region Proposal properties

	    public Guid Id { get; set; }

	    public ObservableCollection<CountryWitCitiesDtoOutput> Countries { get; set; }
	    private CountryWitCitiesDtoOutput _selectedCountry;

	    public CountryWitCitiesDtoOutput SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                _selectedCountry = value;
                OnPropertyChanged(() => SelectedCountry);

                SelectedCity = SelectedCountry.Cities.First();
                OnPropertyChanged(() => SelectedCity);
            }
        }

	    private CityItemDtoOutput _selectedCity;

	    public CityItemDtoOutput SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged(() => SelectedCity);
            }
        }

	    private string _schoolName;

	    public string SchoolName
        {
            get { return _schoolName; }
            set
            {
                _schoolName = value;
                OnPropertyChanged(() => SchoolName);
            }
        }

	    private string _courseName;

	    public string CourseName
        {
            get { return _courseName; }
            set
            {
                _courseName = value;
                OnPropertyChanged(() => CourseName);
            }
        }

	    private ObservableCollection<GuidStringSelected> _intensivityList;

	    public ObservableCollection<GuidStringSelected> IntensivityList
        {
            get { return _intensivityList; }
            set
            {
                _intensivityList = value;
                OnPropertyChanged(() => IntensivityList);
            }
        }

	    private ObservableCollection<GuidStringSelected> _houseTypeList;

	    public ObservableCollection<GuidStringSelected> HouseTypeList
        {
            get { return _houseTypeList; }
            set
            {
                _houseTypeList = value;
                OnPropertyChanged(() => HouseTypeList);
            }
        }

	    private bool _isGroupType;

	    public bool IsGroupType
        {
            get { return _isGroupType; }
            set
            {
                _isGroupType = value;
                UpdateGroupTypeDependencies(value);
                OnPropertyChanged(() => IsGroupType);
            }
        }

	    private void UpdateGroupTypeDependencies(bool value)
        {
            if (value)
            {
                if (IntensivityList != null && HouseTypeList != null)
                {
                    foreach (GuidStringSelected item in IntensivityList)
                    {
                        item.IsSelected = false;
                    }

                    IntensivityList.First().IsSelected = true;

                    foreach (GuidStringSelected item in HouseTypeList)
                    {
                        item.IsSelected = false;
                    }
                    HouseTypeList.First().IsSelected = true;
                }
            }
        }

	    private string _curatorName;

	    public string CuratorName
        {
            get { return _curatorName; }
            set
            {
                _curatorName = value;
                OnPropertyChanged(() => CuratorName);
            }
        }

	    private DateTime _startDate;

	    public DateTime StartDate
        {
            get
            {
                if (_startDate == default(DateTime))
                {
                    _startDate = DateTime.Now;
                    OnPropertyChanged(() => StartDate);
                }

                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged(() => StartDate);
            }
        }

	    private DateTime _endDate;

	    public DateTime EndDate
        {
            get
            {
                if (_endDate == default(DateTime))
                {
                    _endDate = DateTime.Now;
                    OnPropertyChanged(() => StartDate);
                }

                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged(() => EndDate);
            }
        }

	    #endregion
    }
}