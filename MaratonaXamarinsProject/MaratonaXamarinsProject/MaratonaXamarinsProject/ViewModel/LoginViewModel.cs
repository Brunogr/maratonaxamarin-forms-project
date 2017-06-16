using MaratonaXamarinsProject.Helpers;
using MaratonaXamarinsProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaratonaXamarinsProject.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginWithFacebookCommand { get; }
        private readonly IMaratonaXamarinService _maratonaXamarinService;
        private readonly IAzureServiceAuth _azureServiceAuthService;

        public LoginViewModel(IMaratonaXamarinService maratonaXamarinService, IAzureServiceAuth azureServiceAuth)
        {
            _maratonaXamarinService = maratonaXamarinService;
            _azureServiceAuthService = azureServiceAuth;
            LoginWithFacebookCommand = new Command(ExecuteLoginWithFacebookCommand);

        }

        private async void ExecuteLoginWithFacebookCommand()
        {
            var user = await _azureServiceAuthService.LoginAsync();
            var token = await _azureServiceAuthService.GetFacebookTokenAsync(Settings.AuthToken);
            Settings.FacebookToken = token.access_token;

            await PushAsync<MainViewModel>();            
        }

        private string _infoLabel;

        public string InfoLabel
        {
            get { return _infoLabel; }
            set
            {
                SetProperty(ref _infoLabel, value);
            }
        }
    }
}
