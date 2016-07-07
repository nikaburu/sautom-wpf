using System.Windows.Controls;
using Sautom.Client.Modules.Report.ViewModels;

namespace Sautom.Client.Modules.Report.Views
{
    /// <summary>
    /// Interaction logic for ReportIndex.xaml
    /// </summary>
    public partial class ReportIndex : UserControl
    {
	    public ReportIndex(ReportIndexViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
