using System.Windows.Controls;
using Sautom.Client.Modules.EventNortification.ViewModels;

namespace Sautom.Client.Modules.EventNortification.Views
{
    /// <summary>
    /// Interaction logic for EventNotificationList.xaml
    /// </summary>
    public partial class EventNotificationList : UserControl
    {
	    public EventNotificationList(EventNotificationListViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
