using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using BooksLib.ViewModels;

namespace BooksApp_Xamarin
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            //Appearing += OnAppearing;
            //Disappearing += OnDisappearing;

            //_scope = AppServices.Instance.ServiceProvider.CreateScope();
            //ViewModel = _scope.ServiceProvider.GetRequiredService<BooksViewModel>();
            InitializeComponent();
        }

        //private void OnAppearing(object sender, EventArgs e)
        //{

        //}

        //private void OnDisappearing(object sender, EventArgs e)
        //{
        //    _scope?.Dispose();
        //    _scope = null;

        //    Disappearing += OnDisappearing;
        //}

       // public BooksViewModel ViewModel { get; private set; }
        
    }
}
