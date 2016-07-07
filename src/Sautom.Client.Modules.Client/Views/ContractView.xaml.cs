using System.Windows.Controls;
using Sautom.Client.Modules.Client.ViewModels;

namespace Sautom.Client.Modules.Client.Views
{
    /// <summary>
    /// Interaction logic for ContractView.xaml
    /// </summary>
    public partial class ContractView : UserControl
    {
	    public ContractView(ContractViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
