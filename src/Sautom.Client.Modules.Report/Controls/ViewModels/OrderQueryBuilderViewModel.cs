using System;
using System.Windows.Input;
using Prism.Mvvm;

namespace Sautom.Client.Modules.Report.Controls.ViewModels
{
    public sealed class OrderQueryBuilderViewModel : BindableBase
    {
	    #region Constructor

	    public OrderQueryBuilderViewModel(ICommand doSearch)
        {
            DoSearch = doSearch;

            StartDate = DateTime.Now.AddMonths(-1);
            EndDate = DateTime.Now;
        }

	    #endregion

	    #region Commands

	    public ICommand DoSearch { get; set; }

	    #endregion

	    #region For View properties

	    public string ClientName { get; set; }

	    public string SchoolName { get; set; }
	    public string CourceName { get; set; }

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

	    #endregion
    }
}