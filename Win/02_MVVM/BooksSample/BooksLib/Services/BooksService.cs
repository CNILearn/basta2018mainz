using BooksLib.Models;
using GenericViewModels.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLib.Services
{
    public class BooksService : ItemsService<Book>
    {
        private readonly IRepository<Book, int> _booksRepository;

        public BooksService(
            IRepository<Book, int> booksRepository,
            ISharedItems<Book> sharedItemsService, 
            ILoggerFactory loggerFactory) 
            : base(sharedItemsService, loggerFactory)
        {
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
        }

        public override async Task RefreshAsync()
        {
            IEnumerable<Book> books = await _booksRepository.GetItemsAsync();
            Items.Clear();

            foreach (var book in books)
            {
                Items.Add(book);
            }

            SetSelectedItem(Items.FirstOrDefault());
            await base.RefreshAsync();
        }

        public override async Task<Book> AddOrUpdateAsync(Book item)
        {
            Book updated = null;
            if (item.BookId <= 0)
            {
                updated = await _booksRepository.AddAsync(item);
            }
            else
            {
                updated = await _booksRepository.UpdateAsync(item);
            }
            ReplaceItemInItems(updated);
            SetSelectedItem(updated);
            return updated;
        }

        private void ReplaceItemInItems(Book item)
        {
            var oldItem = Items.SingleOrDefault(b => b.BookId == item.BookId);
            if (oldItem != null)
            {
                int index = Items.IndexOf(oldItem);
                Items.RemoveAt(index);
                Items.Insert(index, item);
            }
            else
            {
                Items.Add(item);
            }
        }

        public override async Task DeleteAsync(Book item)
        {
            await _booksRepository.DeleteAsync(item.BookId);
            Items.Remove(item);
            SetSelectedItem(Items.FirstOrDefault());
        }
    }
}
