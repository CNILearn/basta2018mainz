using System;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage() => InitializeComponent();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (!string.IsNullOrEmpty(e.Parameter?.ToString()))
            {
                textParameter.Text = e.Parameter.ToString();
            }

            this.packageFamilyName.Text = Package.Current.Id.FamilyName;
        }





        private AppServiceConnection _appServiceConnection;

        private async void OnWPFAppService(object sender, RoutedEventArgs e)
        {
            _appServiceConnection = new AppServiceConnection();
            _appServiceConnection.AppServiceName = "com.cninnovation.wpfbridgesample";
            _appServiceConnection.PackageFamilyName = "676efced-1da0-481b-8db0-97f991f1c4d0_2dq4k2rrbc0fy";

            _appServiceConnection.RequestReceived += OnRequestReceived;
            AppServiceConnectionStatus status = await _appServiceConnection.OpenAsync();
            if (status == AppServiceConnectionStatus.Success)
            {
                var valueSet = new ValueSet();
                valueSet.Add("command", "test");
                AppServiceResponse response = await _appServiceConnection.SendMessageAsync(valueSet);
                if (response.Status == AppServiceResponseStatus.Success)
                {
                    string answer = string.Join(", ", response.Message.Values.Cast<string>().ToArray());
                    await new MessageDialog($"received {answer}").ShowAsync();
                }
                else
                {
                    await new MessageDialog("error send").ShowAsync();
                }
            }
            else
            {
                await new MessageDialog(status.ToString()).ShowAsync();
            }
        }

        private void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {

        }


        //private async void OnAppService(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        //    using (var connection = new AppServiceConnection())
        //    {
        //        connection.AppServiceName = "com.cninnovation.bridgesample";
        //        connection.PackageFamilyName = "6d982834-6814-4d82-b331-8644a7f54418_2dq4k2rrbc0fy";

        //        AppServiceConnectionStatus status = await connection.OpenAsync();
        //        if (status == AppServiceConnectionStatus.Success)
        //        {
        //            var valueSet = new ValueSet();
        //            valueSet.Add("command", "test");
        //            AppServiceResponse response = await connection.SendMessageAsync(valueSet);
        //            if (response.Status == AppServiceResponseStatus.Success)
        //            {
        //                string answer = string.Join(", ", response.Message.Values.Cast<string>().ToArray());
        //                await new MessageDialog($"received {answer}").ShowAsync();
        //                //      await _dialogService.ShowMessageAsync($"received {answer}");
        //            }//
        //            else
        //            {
        //                await new MessageDialog("error send").ShowAsync();
        //                // await _dialogService.ShowMessageAsync($"error sending message {response.Status.ToString()}");
        //            }
        //        }
        //        else
        //        {
        //            await new MessageDialog(status.ToString()).ShowAsync();
        //       //     await _dialogService.ShowMessageAsync(status.ToString());
        //        }
        //    }
        //}
    }
}
