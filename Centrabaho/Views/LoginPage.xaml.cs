namespace Centrabaho.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	//Hyperlink leads to sign up page
    private void register_hyperlink(object sender, TappedEventArgs e)
    {
		navigateTo("registerpage");
    }

	//Navigation Command
	private async Task navigateTo(string path)
	{
		await Shell.Current.GoToAsync(path);
	}
}