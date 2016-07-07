using System.Windows.Controls;
using Sautom.Client.Modules.Client.ViewModels;

namespace Sautom.Client.Modules.Client.Views
{
    /// <summary>
    /// Interaction logic for ClientAddNewOrder.xaml
    /// </summary>
    public partial class EditOrderAdvanced : UserControl
    {
	    public EditOrderAdvanced(EditOrderAdvancedViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
