using System.Windows.Controls;
using Sautom.Client.Modules.Report.ViewModels;

namespace Sautom.Client.Modules.Report.Views
{
    /// <summary>
    /// Interaction logic for ReportIndex.xaml
    /// </summary>
    public partial class OrdersReport : UserControl
    {
	    public OrdersReport(OrdersReportViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
