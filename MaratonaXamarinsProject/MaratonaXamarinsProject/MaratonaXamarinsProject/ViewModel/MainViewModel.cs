using MaratonaXamarinsProject.Helpers;
using MaratonaXamarinsProject.Model;
using MaratonaXamarinsProject.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaratonaXamarinsProject.ViewModel
{
    public class MainViewModel :BaseViewModel
    {
        private readonly IMaratonaXamarinService _maratonaXamarinService;

        private FacebookModel _user;
        public FacebookModel User {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private FacebookMovieModel _userMovies;
        public FacebookMovieModel UserMovies
        {
            get { return _userMovies; }
            set { SetProperty(ref _userMovies, value); }
        }

        public Command MovieDetailsCommand { get; }

        public ObservableCollection<Movie> Movies { get; }
        public MainViewModel(IMaratonaXamarinService maratonaXamarinService)
        {
            _maratonaXamarinService = maratonaXamarinService;
            Movies = new ObservableCollection<Movie>();
            MovieDetailsCommand = new Command<Movie>(ExecuteMovieDetailsCommand);

            

            //GetUser();

        }

        private async void ExecuteMovieDetailsCommand(Movie movie)
        {
            await PushAsync<ContentWebViewModel>(movie);
        }

        public override async Task LoadAsync()
        {
            User = await _maratonaXamarinService.GetUserAsync();

            Title = $"Filmes de {User.Name}";

            var movies = await _maratonaXamarinService.GetMoviesAsync();

            Movies.Clear();

            foreach (var movie in movies.data)
            {
                Movies.Add(movie.data.movie);
            }


        }

        private async void GetUser()
        {
            User = await _maratonaXamarinService.GetUserAsync();
            UserMovies = await _maratonaXamarinService.GetMoviesAsync();
        }
    }
}
