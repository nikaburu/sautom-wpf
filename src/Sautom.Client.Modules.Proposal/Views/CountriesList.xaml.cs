using System.Windows.Controls;
using Sautom.Client.Modules.Proposal.ViewModels;

namespace Sautom.Client.Modules.Proposal.Views
{
    /// <summary>
    /// Interaction logic for ProposalIndex.xaml
    /// </summary>
    public partial class CountriesList : UserControl
    {
	    public CountriesList(CountriesListViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
