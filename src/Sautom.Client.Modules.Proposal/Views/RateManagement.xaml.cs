using System.Windows.Controls;
using Sautom.Client.Modules.Proposal.ViewModels;

namespace Sautom.Client.Modules.Proposal.Views
{
    /// <summary>
    /// Interaction logic for RateManagement.xaml
    /// </summary>
    public partial class RateManagement : UserControl
    {
	    public RateManagement(RateManagementViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
