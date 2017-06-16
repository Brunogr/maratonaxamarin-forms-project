using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MaratonaXamarinsProject.Authenticate;
using Microsoft.WindowsAzure.MobileServices;
using MaratonaXamarinsProject.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MaratonaXamarinsProject.Droid.AuthenticateDroid))]
namespace MaratonaXamarinsProject.Droid
{
    public class AuthenticateDroid : IAuthenticate
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                var user = await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken;
                Settings.UserId = user?.UserId;
                return user;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}