using System.Windows.Controls;
using Sautom.Client.Modules.Client.ViewModels;

namespace Sautom.Client.Modules.Client.Views
{
    /// <summary>
    /// Interaction logic for ClientDetails.xaml
    /// </summary>
    public partial class ClientDetails : UserControl
    {
	    public ClientDetails(ClientDetailsViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
