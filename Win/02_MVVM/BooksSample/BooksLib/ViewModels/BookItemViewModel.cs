using BooksLib.Models;
using GenericViewModels.Services;
using GenericViewModels.ViewModels;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using System;

namespace BooksLib.ViewModels
{
    public class BookItemViewModel : ItemViewModel<Book>
    {
        private readonly IItemsService<Book> _booksService;
        private readonly ILogger _logger;

        public BookItemViewModel(
            Book item, 
            IItemsService<Book> booksService,
            IShowProgressInfo showProgressInfo,
            ILoggerFactory loggerFactory) 
            : base(item, showProgressInfo)
        {
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
            _logger = loggerFactory?.CreateLogger(GetType()) ?? throw new ArgumentNullException(nameof(loggerFactory));

            ProgressInfoName = "Default";
            DeleteBookCommand = new DelegateCommand(OnDeleteBook);
        }

        public DelegateCommand DeleteBookCommand { get; }

        private async void OnDeleteBook()
        {
            using (_showProgressInfo.StartInProgress(ProgressInfoName))
            {
                try
                {
                    await _booksService.DeleteAsync(Item);
                }
                catch (Exception ex)
                {
                    // TODO: show error to the user
                    _logger.LogError(ex, ex.Message);
                }
            }
        }

        public override string ToString() => Item.ToString();
    }
}
