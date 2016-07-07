using System.Windows.Controls;
using Sautom.Client.Modules.Proposal.ViewModels;

namespace Sautom.Client.Modules.Proposal.Views
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
