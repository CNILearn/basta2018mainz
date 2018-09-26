using Microsoft.Toolkit.Wpf.UI.XamlHost;
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

namespace XAMLHostSample
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

        private void OnHostChildChanged(object sender, EventArgs e)
        {
            if (sender is WindowsXamlHost host)
            {
                if (host.Child is Windows.UI.Xaml.Controls.Button button)
                {
                    button.Content = "My UWP Button";
                    button.Click += (sender1, e1) =>
                    {
                        MessageBox.Show("UWP button clicked");
                    };
                }
            }
        }
    }
}
