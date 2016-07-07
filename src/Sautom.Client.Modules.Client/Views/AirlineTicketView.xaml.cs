using System.Windows.Controls;
using Sautom.Client.Modules.Client.ViewModels;

namespace Sautom.Client.Modules.Client.Views
{
    /// <summary>
    /// Interaction logic for AirlineTicketView.xaml
    /// </summary>
    public partial class AirlineTicketView : UserControl
    {
	    public AirlineTicketView(AirlineTicketViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
