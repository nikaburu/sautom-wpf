using System.Windows.Controls;
using Sautom.Client.Modules.Client.ViewModels;

namespace Sautom.Client.Modules.Client.Views
{
    /// <summary>
    /// Interaction logic for ClientAddNewOrder.xaml
    /// </summary>
    public partial class ClientAddNewOrder : UserControl
    {
	    public ClientAddNewOrder(ClientAddNewOrderViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
