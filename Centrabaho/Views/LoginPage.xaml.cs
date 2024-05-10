using Centrabaho.ViewModels;

namespace Centrabaho.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
        var viewmodel = new LoginViewModel();
        BindingContext = viewmodel;
		InitializeComponent();
	}

	//Hyperlink leads to sign up page
    private void register_hyperlink(object sender, TappedEventArgs e)
    {
		navigateTo("registerpage");
    }

    //Toggle password visibility
    private void passwordBtn_Clicked(object sender, EventArgs e)
    {
        if (passwordEntry.IsPassword)
        {
            passwordEntry.IsPassword = false;
            passwordBtn.ImageSource = "password_shown.png";
            return;
        }
        passwordEntry.IsPassword = true;
        passwordBtn.ImageSource = "password_hidden.png";
    }

    //Navigation Command
    private async Task navigateTo(string path)
	{
		await Shell.Current.GoToAsync(path);
	}

    private void loginBtn_Clicked(object sender, EventArgs e)
    {
        usernameEntry.Text = string.Empty;
        passwordEntry.Text = string.Empty;
    }
}