using MaratonaXamarinsProject.Service;
using MaratonaXamarinsProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaratonaXamarinsProject
{
    public partial class LoginPage
    {
        public LoginPage()
        {
            InitializeComponent();
            var maratonaXamarinService = DependencyService.Get<IMaratonaXamarinService>();
            var azureAuthService = DependencyService.Get<IAzureServiceAuth>();
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new LoginViewModel(maratonaXamarinService, azureAuthService);
        }
    }
}
