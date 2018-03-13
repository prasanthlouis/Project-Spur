using Contacts;
using ContactsUI;
using Foundation;
using System;
using System.Collections.Generic;
using System.Windows.Input;

using Xamarin.Forms;

namespace ProjectSpur.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => ShowContacts());
        }

        private void ShowContacts()
        {
            var picker = new CNContactPickerViewController();
            picker.DisplayedPropertyKeys = new NSString[] { CNContactKey.Nickname };
        }

        public ICommand OpenWebCommand { get; }
    }
}