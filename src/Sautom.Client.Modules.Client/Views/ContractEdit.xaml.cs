using System.Windows.Controls;
using Sautom.Client.Modules.Client.ViewModels;

namespace Sautom.Client.Modules.Client.Views
{
    /// <summary>
    /// Interaction logic for ContractEdit.xaml
    /// </summary>
    public partial class ContractEdit : UserControl
    {
	    public ContractEdit(ContractEditViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
