using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProjectSpur.Models;

[assembly: Xamarin.Forms.Dependency(typeof(ProjectSpur.Services.MockDataStore))]
namespace ProjectSpur.Services
{
    public class MockDataStore : IDataStore<Friend>
    {
        List<Friend> friends;

        public MockDataStore()
        {
            friends = new List<Friend>();
            var mockItems = new List<Friend>
            {
                new Friend()
                {
                    FirstName = "Albert",
                    LastName = "George"
                }
            };

            foreach (var friend in mockItems)
            {
                friends.Add(friend);
            }
        }

        public async Task<bool> AddItemAsync(Friend friend)
        {
            friends.Add(friend);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Friend friend)
        {
            var _friends = friends.Where((Friend arg) => arg.Id == friend.Id).FirstOrDefault();
            friends.Remove(_friends);
            friends.Add(friend);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Friend friend)
        {
            var _friends = friends.Where((Friend arg) => arg.Id == friend.Id).FirstOrDefault();
            friends.Remove(_friends);

            return await Task.FromResult(true);
        }

        public async Task<Friend> GetItemAsync(string id)
        {
            return await Task.FromResult(friends.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Friend>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(friends);
        }
    }
}