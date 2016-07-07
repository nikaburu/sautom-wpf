using Microsoft.Windows.Controls.Ribbon;
using Sautom.Client.Ui.ViewModels;

namespace Sautom.Client.Ui.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
	    public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            // Set the ViewModel as this View's data context.
            DataContext = viewModel;
        }
    }
}
