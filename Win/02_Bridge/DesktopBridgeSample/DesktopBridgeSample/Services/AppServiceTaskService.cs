using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace DesktopBridgeSample.Services
{
    public class AppServiceTaskService : IAppServiceTaskService
    {
        private readonly IDialogService _dialogService;
        public AppServiceTaskService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        private AppServiceConnection _appServiceConnection;

        public Task StartTaskAsync()
        {
            async void Run()
            {
                try
                {
                    _appServiceConnection = new AppServiceConnection();
                    _appServiceConnection.AppServiceName = "com.cninnovation.wpfbridgesample";
                    _appServiceConnection.PackageFamilyName = Package.Current.Id.FamilyName;
                    _appServiceConnection.RequestReceived += OnRequestReceived;

                    AppServiceConnectionStatus status = await _appServiceConnection.OpenAsync();
                    if (status == AppServiceConnectionStatus.Success)
                    {
                        await _dialogService.ShowMessageAsync("Successfully started App-Service");
                        var message = new ValueSet();
                        message.Add("command", "Hello");
                        var response = await _appServiceConnection.SendMessageAsync(message);

                        await _dialogService.ShowMessageAsync(response.Status.ToString());
                    }
                    else
                    {
                        await _dialogService.ShowMessageAsync(status.ToString());
                    }
                }
                catch (InvalidOperationException)
                {
                    await _dialogService.ShowMessageAsync("invalid operation - are you running with a package?");
                }
            }

            var t1 = new Task(Run, TaskCreationOptions.LongRunning);
            t1.Start();
            return t1;
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            string keys = string.Join(", ", args.Request.Message.Keys);
            string values = string.Join(", ", args.Request.Message.Values);
            await _dialogService.ShowMessageAsync($"received {keys}; {values}");
        }

        //public async Task SendMessageAsync(string message)
        //{
        //    using (var connection = new AppServiceConnection())
        //    {
        //        connection.AppServiceName = "com.cninnovation.bridgesample";
        //        connection.PackageFamilyName = "6d982834-6814-4d82-b331-8644a7f54418_2dq4k2rrbc0fy";

        //        AppServiceConnectionStatus status = await connection.OpenAsync();
        //        if (status == AppServiceConnectionStatus.Success)
        //        {
        //            var valueSet = new ValueSet();
        //            valueSet.Add("command", message);
        //            AppServiceResponse response = await connection.SendMessageAsync(valueSet);
        //            if (response.Status == AppServiceResponseStatus.Success)
        //            {
        //                string answer = string.Join(", ", response.Message.Values.Cast<string>().ToArray());
        //                await _dialogService.ShowMessageAsync($"received {answer}");
        //            }
        //            else
        //            {
        //                await _dialogService.ShowMessageAsync($"error sending message {response.Status.ToString()}");
        //            }
        //        }
        //        else
        //        {
        //            await _dialogService.ShowMessageAsync(status.ToString());
        //        }
        //    }
        //}
    }
}
