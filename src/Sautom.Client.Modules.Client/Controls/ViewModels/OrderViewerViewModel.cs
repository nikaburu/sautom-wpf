using System;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;
using Sautom.Client.Comunication.Commands;
using Sautom.Client.Comunication.QueriesService;
using Sautom.Client.Modules.Client.Models;

namespace Sautom.Client.Modules.Client.Controls.ViewModels
{
    public class OrderViewerViewModel : BindableBase
    {
	    public OrderViewerViewModel(CommandBase<Guid> printOrderDetails)
        {
            PrintOrderDetails = printOrderDetails;
        }

	    #region Commands

	    public CommandBase<Guid> PrintOrderDetails { get; }

	    #endregion

	    #region View properties

	    public bool IsShowAirlineTicket
        {
            get { return Order != null && Order.AirlineTicket != null && Order.AirlineTicket.Id != Guid.Empty; }
        }

	    private ObservableCollection<GuidStringSelected> _embasyDocs;

	    public ObservableCollection<GuidStringSelected> EmbasyDocs
        {
            get { return _embasyDocs; }
            set
            {
                _embasyDocs = value;
                OnPropertyChanged(() => EmbasyDocs);
            }
        }

	    private OrderItemDtoOutput _order;

	    public OrderItemDtoOutput Order
        {
            get { return _order; }
            set
            {
                PreSelectionAction(Order);
                _order = value;
                OnPropertyChanged(() => Order);
                InitializeDependencies(value);
            }
        }

	    private void InitializeDependencies(OrderItemDtoOutput value)
        {
            if (value != null)
            {
                EmbasyDocs = new ObservableCollection<GuidStringSelected>(value.FullDocsList.Select(
                    rec =>
                    new GuidStringSelected { Id = rec.Id, Value = rec.Element, IsSelected = value.Docs.Contains(rec.Id) }));

                OnPropertyChanged(() => IsShowAirlineTicket); 
                PrintOrderDetails.RaiseCanExecuteChanged();
            }
        }

	    private void PreSelectionAction(OrderItemDtoOutput value)
        {
            if (value != null)
            {
                value.Docs = EmbasyDocs.Where(rec => rec.IsSelected).Select(rec => rec.Id).ToArray();
            }
        }

	    #endregion
    }
}
