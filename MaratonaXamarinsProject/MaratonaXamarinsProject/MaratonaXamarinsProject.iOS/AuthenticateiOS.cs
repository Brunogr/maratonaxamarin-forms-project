using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MaratonaXamarinsProject.Authenticate;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using MaratonaXamarinsProject.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MaratonaXamarinsProject.iOS.AuthenticateiOS))]
namespace MaratonaXamarinsProject.iOS
{
    public class AuthenticateiOS : IAuthenticate
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                var user = await client.LoginAsync(UIKit.UIApplication.SharedApplication.KeyWindow.RootViewController, provider);
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