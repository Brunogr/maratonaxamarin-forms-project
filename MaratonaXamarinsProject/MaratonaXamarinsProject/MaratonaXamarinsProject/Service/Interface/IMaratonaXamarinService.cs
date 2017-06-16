using MaratonaXamarinsProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaXamarinsProject.Service
{
    public interface IMaratonaXamarinService
    {
        Task<FacebookModel> GetUserAsync();
        Task<FacebookMovieModel> GetMoviesAsync();

    }
}
