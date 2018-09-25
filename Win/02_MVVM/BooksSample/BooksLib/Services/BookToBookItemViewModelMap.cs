using BooksLib.Models;
using BooksLib.ViewModels;
using Generic.ViewModels.Services;
using GenericViewModels.Services;
using Microsoft.Extensions.Logging;
using System;

namespace BooksLib.Services
{
    public class BookToBookItemViewModelMap : ItemToViewModelMap<Book, BookItemViewModel>
    {
        private readonly IItemsService<Book> _itemsService;
        private readonly IShowProgressInfo _showProgressInfo;
        private readonly ILoggerFactory _loggerFactory;
        public BookToBookItemViewModelMap(
            IItemsService<Book> itemsService,
            IShowProgressInfo showProgressInfo,
            ILoggerFactory loggerFactory)
        {
            _itemsService = itemsService ?? throw new ArgumentNullException(nameof(itemsService));
            _showProgressInfo = showProgressInfo ?? throw new ArgumentNullException(nameof(showProgressInfo));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }
        protected override BookItemViewModel CreateViewModel(Book item) =>
            new BookItemViewModel(item, _itemsService, _showProgressInfo, _loggerFactory);
    }
}
