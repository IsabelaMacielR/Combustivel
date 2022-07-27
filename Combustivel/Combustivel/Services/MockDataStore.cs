using Combustivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Combustivel.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        readonly List<Item> users;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };

            users = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Nome = "Name", CPF="123456789" },
                new Item { Id = Guid.NewGuid().ToString(), Nome = "Name", CPF="123456789" },
                new Item { Id = Guid.NewGuid().ToString(), Nome = "Name", CPF="123456789" },
                new Item { Id = Guid.NewGuid().ToString(), Nome = "Name", CPF="123456789" },
                new Item { Id = Guid.NewGuid().ToString(), Nome = "Name", CPF="123456789" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> AddUserAsync(Item user)
        {
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateUserAsync(Item user)
        {
            var oldUser = users.Where((Item arg) => arg.Id == user.Id).FirstOrDefault();
            users.Remove(oldUser);
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var oldUser = users.Where((Item arg) => arg.Id == id).FirstOrDefault();
            users.Remove(oldUser);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<Item> GetUserAsync(string id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Item>> GetUserAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }
    }

}