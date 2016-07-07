using System.Windows.Controls;
using Sautom.Client.Modules.Authorization.ViewModels;

namespace Sautom.Client.Modules.Authorization.Views
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : UserControl
    {
	    public ChangePassword(ChangePasswordViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
