using System.Windows.Controls;
using Sautom.Client.Modules.Client.ViewModels;

namespace Sautom.Client.Modules.Client.Views
{
    /// <summary>
    /// Interaction logic for ClientIndex.xaml
    /// </summary>
    public partial class ClientIndex : UserControl
    {
	    public ClientIndex(ClientIndexViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
