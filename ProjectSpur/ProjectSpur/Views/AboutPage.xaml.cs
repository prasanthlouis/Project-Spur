using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectSpur.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			InitializeComponent ();
		}
        async void OpenContacts(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}