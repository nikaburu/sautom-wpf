using System.Windows.Controls;
using Sautom.Client.Modules.Report.ViewModels;

namespace Sautom.Client.Modules.Report.Views
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
