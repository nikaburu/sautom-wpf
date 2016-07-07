using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Sautom.Client.Modules.Proposal.ViewModels;

namespace Sautom.Client.Modules.Proposal.Views
{
    /// <summary>
    /// Interaction logic for ProposalEdit.xaml
    /// </summary>
    public partial class CountryEdit : UserControl
    {
	    public CountryEdit(CountryEditViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }

	    private void AddCityButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                ICommand command = button.Command;
                if (command != null)
                    command.Execute(button.CommandParameter);

                cityTextbox.Text = "";
            }
        }

	    private void AddDocumentButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                ICommand command = button.Command;
                if (command != null)
                    command.Execute(button.CommandParameter);

                documentTextbox.Text = "";
            }
        }
    }
}
