using MaratonaXamarinsProject.Authenticate;
using Microsoft.WindowsAzure.MobileServices;
using MaratonaXamarinsProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using MaratonaXamarinsProject.Model;

[assembly: Dependency(typeof(MaratonaXamarinsProject.Service.AzureService))]
namespace MaratonaXamarinsProject.Service
{
    public class AzureService : IAzureServiceAuth
    {
        public AzureService()
        {

        }
        static readonly string AppUrl = "http://maratonaxamarin-roldao.azurewebsites.net";
        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
        }

        public async Task<MobileServiceUser> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthenticate>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Não conseguimos efetuar o seu login, tente novamente!", "OK");
                });
                return null;
            }
            return user;
        }

        public async Task<FacebookTokenModel> GetFacebookTokenAsync(string token)
        {
            var httpClient = new HttpClient();
            //httpClient.GetAsync($"{AppUrl}/User?token={token}&ZUMO-API-VERSION=2.0.0");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{AppUrl}/.auth/me?ZUMO-API-VERSION=2.0.0");
            request.Headers.Add("X-ZUMO-AUTH", token);
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            //var response = await httpClient.GetAsync($"{AppUrl}/User?ZUMO-API-VERSION=2.0.0").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    var user = await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false);

                    var model = JsonConvert.DeserializeObject<List<FacebookTokenModel>>(user);

                    return model.FirstOrDefault();
                }
            }

            return null;
        }
    }
}
