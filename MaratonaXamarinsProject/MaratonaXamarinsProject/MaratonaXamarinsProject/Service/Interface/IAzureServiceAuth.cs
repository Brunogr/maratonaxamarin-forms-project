using MaratonaXamarinsProject.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaXamarinsProject.Service
{
    public interface IAzureServiceAuth
    {
        Task<MobileServiceUser> LoginAsync();
        Task<FacebookTokenModel> GetFacebookTokenAsync(string token);
    }
}
