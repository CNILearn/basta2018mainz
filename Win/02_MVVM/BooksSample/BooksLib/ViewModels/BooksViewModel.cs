using BooksLib.Models;
using Generic.ViewModels.Services;
using GenericViewModels.Services;
using GenericViewModels.ViewModels;
using Microsoft.Extensions.Logging;

namespace BooksLib.ViewModels
{

    public class BooksViewModel : MasterDetailViewModel<BookItemViewModel, Book>
    {
        public BooksViewModel(
            IItemsService<Book> itemsService, 
            IItemToViewModelMap<Book, BookItemViewModel> viewModelMap, 
            IShowProgressInfo showProgressInfo, ILoggerFactory loggerFactory) 
            : base(itemsService, viewModelMap, showProgressInfo, loggerFactory)
        {
        }
    }
}
