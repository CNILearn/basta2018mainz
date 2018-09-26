using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksLib.Services
{
    public interface IRepository<T, in TKey>
    {
        Task<T> GetItemAsync(TKey id);
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(TKey id);
    }
}
