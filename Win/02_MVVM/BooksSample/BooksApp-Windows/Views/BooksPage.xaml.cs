using BooksLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace BooksApp_Windows.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BooksPage : Page
    {
        private IServiceScope _scope;

        public BooksPage()
        {
            InitializeComponent();

            _scope = AppServices.Instance.ServiceProvider.CreateScope();
            Unloaded += (sender, e) => _scope.Dispose();

            // BookDetailUC.ViewModel = _scope.ServiceProvider.GetRequiredService<BookDetailViewModel>();
            ViewModel = _scope.ServiceProvider.GetRequiredService<BooksViewModel>();
        }

        public BooksViewModel ViewModel { get; }
    }
}
