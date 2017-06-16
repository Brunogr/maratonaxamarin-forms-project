using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaratonaXamarinsProject.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MaratonaXamarinsProject.UWP.AuthenticateUWP))]
namespace MaratonaXamarinsProject.UWP
{
    public class AuthenticateUWP
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                var user = await client.LoginAsync(provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken;
                Settings.UserId = user?.UserId;
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
