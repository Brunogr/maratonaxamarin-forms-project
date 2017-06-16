using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaratonaXamarinsProject.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MaratonaXamarinsProject.Service;

namespace MaratonaXamarinsProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;
        public MainPage()
        {
            InitializeComponent();
            var maratonaXamarinService = DependencyService.Get<IMaratonaXamarinService>();

            BindingContext = new MainViewModel(maratonaXamarinService);
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.MovieDetailsCommand.Execute(e.SelectedItem);
            }
        }
    }
}