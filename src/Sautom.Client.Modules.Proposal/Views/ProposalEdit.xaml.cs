using System.Windows.Controls;
using Sautom.Client.Modules.Proposal.ViewModels;

namespace Sautom.Client.Modules.Proposal.Views
{
    /// <summary>
    /// Interaction logic for ProposalEdit.xaml
    /// </summary>
    public partial class ProposalEdit : UserControl
    {
	    public ProposalEdit(ProposalEditViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
