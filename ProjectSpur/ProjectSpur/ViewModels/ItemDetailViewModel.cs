using System;

using ProjectSpur.Models;

namespace ProjectSpur.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item friends = null)
        {
            Title = friends?.Text;
            Item = friends;
        }
    }
}
