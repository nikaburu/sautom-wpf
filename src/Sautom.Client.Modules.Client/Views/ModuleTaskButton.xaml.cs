using System.Windows.Controls;
using Sautom.Client.Modules.Client.ViewModels;

namespace Sautom.Client.Modules.Client.Views
{
    /// <summary>
    /// Interaction logic for ModuleTaskButton.xaml
    /// </summary>
    public partial class ModuleTaskButton : UserControl
    {
	    public ModuleTaskButton(ModuleTaskButtonViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
