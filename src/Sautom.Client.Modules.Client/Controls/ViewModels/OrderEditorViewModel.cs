using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Modules.Client.Models;

namespace Sautom.Client.Modules.Client.Controls.ViewModels
{
    public class OrderEditorViewModel : BindableBase
    {
	    public OrderEditorViewModel(DelegateCommand saveCommand, ProposalDtoOutput[] proposals, ManagerDtoOutput[] responsibleManagers)
        {
            SaveCommand = saveCommand;

            Proposals = proposals.ToList();
            SelectedProposal = Proposals.FirstOrDefault();

            Managers = responsibleManagers.ToList();
            SelectedManager = Managers.First();
        }

	    public DelegateCommand SaveCommand { get; }

	    #region Proposal properties

	    public List<ProposalDtoOutput> Proposals { get; set; }
	    private ProposalDtoOutput _selectedProposal;

	    public ProposalDtoOutput SelectedProposal
        {
            get { return _selectedProposal; }
            set
            {
                _selectedProposal = value;
                OnPropertyChanged(() => SelectedProposal);
                UpdateDependencies(_selectedProposal);
            }
        }

	    private void UpdateDependencies(ProposalDtoOutput selectedProposal)
        {
            IntensityTypes = new ObservableCollection<GuidStringSelected>(selectedProposal.Intensities.Select(rec => new GuidStringSelected { Id = rec.Id, Value = rec.Element }));
            Intensity = IntensityTypes.FirstOrDefault();

            HouseTypeList = new ObservableCollection<GuidStringSelected>(selectedProposal.HouseTypes.Select(rec => new GuidStringSelected { Id = rec.Id, Value = rec.Element }));
            HouseType = HouseTypeList.FirstOrDefault();

            StartDate = selectedProposal.StartDate ?? DateTime.Now;
            EndDate = selectedProposal.EndDate ?? DateTime.Now;
            IsGroupType = selectedProposal.IsGroupType;
        }

	    public List<ManagerDtoOutput> Managers { get; set; }
	    private ManagerDtoOutput _selectedManager;

	    public ManagerDtoOutput SelectedManager
        {
            get { return _selectedManager; }
            set
            {
                _selectedManager = value;
                OnPropertyChanged(() => SelectedManager);
            }
        }

	    private bool _isGroupType;

	    public bool IsGroupType
        {
            get { return _isGroupType; }
            set
            {
                _isGroupType = value;
                OnPropertyChanged(() => IsGroupType);
            }
        }

	    private DateTime _startDate;

	    public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(() => StartDate);
            }
        }

	    private DateTime _endDate;

	    public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(() => EndDate);
            }
        }

	    private ObservableCollection<GuidStringSelected> _intensityTypes;

	    public ObservableCollection<GuidStringSelected> IntensityTypes
        {
            get { return _intensityTypes; }
            set
            {
                _intensityTypes = value;
                OnPropertyChanged(() => IntensityTypes);
            }
        }

	    private GuidStringSelected _intensity;

	    public GuidStringSelected Intensity
        {
            get { return _intensity; }
            set
            {
                _intensity = value;
                OnPropertyChanged(() => Intensity);
                SaveCommand.RaiseCanExecuteChanged();
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

	    private GuidStringSelected _houseType;

	    public GuidStringSelected HouseType
        {
            get { return _houseType; }
            set
            {
                _houseType = value;
                OnPropertyChanged(() => HouseType);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

	    #endregion
    }
}
