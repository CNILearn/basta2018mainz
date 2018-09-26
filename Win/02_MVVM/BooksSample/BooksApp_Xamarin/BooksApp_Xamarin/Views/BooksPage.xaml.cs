using BooksLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksPage : ContentPage
    {
        private IServiceScope _scope;

        public BooksPage()
        {
            InitializeComponent();
            _scope = AppServices.Instance.ServiceProvider.CreateScope();

            ViewModel = _scope.ServiceProvider.GetRequiredService<BooksViewModel>();

            BindingContext = this;

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        public BooksViewModel ViewModel { get; private set; }
    }
}
