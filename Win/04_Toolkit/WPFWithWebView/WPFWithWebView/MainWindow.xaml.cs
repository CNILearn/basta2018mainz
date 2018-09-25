using Microsoft.Toolkit.Wpf.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFWithWebView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WebView_Loaded(object sender, RoutedEventArgs e)
        {
            var webView2 = new WebView(WebView1.Process) { Margin = new Thickness(4) };
            webView2.BeginInit();
            webView2.Source = new Uri("https://www.basta.net");
            webView2.EndInit();

            Grid.SetRow(webView2, 0);
            Grid.SetColumn(webView2, 1);

            Grid1.Children.Add(webView2);
        }
    }
}
