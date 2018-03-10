using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ProjectSpur.Models;
using ProjectSpur.Views;
using System.Collections.Generic;

namespace ProjectSpur.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Friend> Friends { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Friends = new ObservableCollection<Friend>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Friend>(this, "AddItem", async (obj, friends) =>
            {
                var _friends = friends as Friend;
                Friends.Add(_friends);
                await DataStore.AddItemAsync(_friends);
            });
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Friends.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var friends in items)
                {
                    Friends.Add(friends);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}