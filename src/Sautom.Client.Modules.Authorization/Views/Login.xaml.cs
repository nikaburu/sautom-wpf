using System.Windows.Controls;
using Sautom.Client.Modules.Authorization.ViewModels;

namespace Sautom.Client.Modules.Authorization.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
	    public Login(LoginViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
