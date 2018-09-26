using BooksLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BooksApp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IServiceScope _scope;
        public MainWindow()
        {
            InitializeComponent();
            _scope = AppServices.Instance.ServiceProvider.CreateScope();
            Closed += (sender, e) => _scope.Dispose();

            ViewModel = _scope.ServiceProvider.GetRequiredService<BooksViewModel>();

            DataContext = this;

        }

        public BooksViewModel ViewModel { get; }
    }
}
