using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaratonaXamarinsProject.Model;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;
using MaratonaXamarinsProject.Helpers;

[assembly: Dependency(typeof(MaratonaXamarinsProject.Service.MaratonaXamarinService))]
namespace MaratonaXamarinsProject.Service
{
    public class MaratonaXamarinService : IMaratonaXamarinService
    {
        static readonly string AppUrl = "http://maratonaxamarin-roldao.azurewebsites.net/api";
        public async Task<FacebookModel> GetUserAsync()
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            //httpClient.GetAsync($"{AppUrl}/User?token={token}&ZUMO-API-VERSION=2.0.0");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{AppUrl}/User?token={Settings.FacebookToken}&ZUMO-API-VERSION=2.0.0");
            request.Headers.Add("X-ZUMO-AUTH", Settings.AuthToken);
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            //var response = await httpClient.GetAsync($"{AppUrl}/User?ZUMO-API-VERSION=2.0.0").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    var user = await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<FacebookModel>(user.ToString());
                }
            }

            return null;
        }

        public async Task<FacebookMovieModel> GetMoviesAsync()
        {
            var httpClient = new HttpClient();
            var fields = "fields=duration,data{movie{image,name}}";
            //httpClient.GetAsync($"{AppUrl}/User?token={token}&ZUMO-API-VERSION=2.0.0");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{AppUrl}/Movie?token={Settings.FacebookToken}&ZUMO-API-VERSION=2.0.0");
            request.Headers.Add("X-ZUMO-AUTH", Settings.AuthToken);
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            //var response = await httpClient.GetAsync($"{AppUrl}/User?ZUMO-API-VERSION=2.0.0").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    var user = await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false);

                    var model = JsonConvert.DeserializeObject<FacebookMovieModel>(user);

                    return model;
                }
            }

            return null;
        }
    }
}
