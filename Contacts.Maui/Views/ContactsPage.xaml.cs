//
//References:
//https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation?view=net-maui-8.0

using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());

        ListContacts.ItemsSource = contacts;
    }

    private async void ListContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {	
		if(ListContacts.SelectedItem != null)
		{
			//DisplayAlert("test", "test", "OK");
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)ListContacts.SelectedItem).ContactId}");
		}
    }

    private void ListContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        ListContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }
}