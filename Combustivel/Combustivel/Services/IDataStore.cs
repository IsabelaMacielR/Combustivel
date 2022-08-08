using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Combustivel.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

        Task<bool> AddUserAsync(T user);
        Task<bool> UpdateUserAsync(T user);
        Task<bool> DeleteUserAsync(string id);
        Task<T> GetUserAsync(string id);
        Task<IEnumerable<T>> GetUserAsync(bool forceRefresh = false);

        Task<bool> AddDriverAsync(T driver);
        Task<bool> UpdateDriverAsync(T driver);
        Task<bool> DeleteDriverAsync(string id);
        Task<T> GetDriverAsync(string id);
        Task<IEnumerable<T>> GetDriverAsync(bool forceRefresh = false);
    }
}
