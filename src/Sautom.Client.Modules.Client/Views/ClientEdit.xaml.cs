using System.Windows.Controls;
using Sautom.Client.Modules.Client.ViewModels;

namespace Sautom.Client.Modules.Client.Views
{
    /// <summary>
    /// Interaction logic for ClientEdit.xaml
    /// </summary>
    public partial class ClientEdit : UserControl
    {
	    public ClientEdit(ClientEditViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
