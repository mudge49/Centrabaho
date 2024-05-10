using Centrabaho.ViewModels;

namespace Centrabaho.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
        InitializeComponent();
        var viewmodel = new ProfilePageViewModel();
        BindingContext = viewmodel;
	}

    private async Task navigateTo(string url)
    {
        await Shell.Current.GoToAsync(url);
    }

    private void createpostBtn(object sender, EventArgs e)
    {
        _ = navigateTo("createpostpage");
    }

    private void profilepageBtn(object sender, EventArgs e)
    {
        _ = navigateTo("profilepage");
    }

    private void homepageBtn(object sender, EventArgs e)
    {
        _ = navigateTo("homepage");
    }
}