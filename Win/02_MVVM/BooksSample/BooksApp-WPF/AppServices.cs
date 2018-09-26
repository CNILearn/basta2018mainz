using BooksLib.Models;
using BooksLib.Services;
using BooksLib.ViewModels;
using Generic.ViewModels.Services;
using GenericViewModels.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace BooksApp_WPF
{
    public class AppServices
    {
        private AppServices()
        {
            var services = new ServiceCollection();

            // view-models
            services.AddTransient<BooksViewModel>();
            // services.AddTransient<BookDetailViewModel>();

            // services
            services.AddTransient<IItemsService<Book>, BooksService>();
            services.AddTransient<IShowProgressInfo, ShowProgressInfo>();
            // services.AddTransient<IMessageService, UWPMessageService>();

            // stateful services
            services.AddScoped<IItemToViewModelMap<Book, BookItemViewModel>, BookToBookItemViewModelMap>();
            services.AddScoped<ISharedItems<Book>, SharedItems<Book>>();
            services.AddScoped<IRepository<Book, int>, BooksSampleRepository>();

            // logging configuration
            services.AddLogging(builder =>
            {
#if DEBUG
                builder.AddDebug().SetMinimumLevel(LogLevel.Trace);
#endif
            });

            ServiceProvider = services.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get; }

        private static AppServices _instance;
        private static readonly object _instanceLock = new object();
        private static AppServices GetInstance()
        {
            lock (_instanceLock)
            {
                return _instance ?? (_instance = new AppServices());
            }
        }
        public static AppServices Instance => _instance ?? GetInstance();
    }
}
