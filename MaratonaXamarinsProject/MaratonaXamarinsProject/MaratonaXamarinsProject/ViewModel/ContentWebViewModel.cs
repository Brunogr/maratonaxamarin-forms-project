using MaratonaXamarinsProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaXamarinsProject.ViewModel
{
    public class ContentWebViewModel : BaseViewModel
    {
        public Movie Movie { get; }
        public ContentWebViewModel(Movie movie)
        {
            Movie = movie;
            Title = $"Informações de {movie.title}";
        }
    }
}
