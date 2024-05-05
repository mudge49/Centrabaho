using Centrabaho.Services;

namespace Centrabaho.Views;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        _ = new LocalDbService().DeleteAllPosts();
        confirm();
        
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        _ = new LocalDbService().DeleteAllUsers();
        confirm();
    }

    private async Task confirm()
    {
        await Shell.Current.DisplayAlert("Yes", "Yes", "Yes");
    }
}