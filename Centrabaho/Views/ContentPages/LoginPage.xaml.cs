using Centrabaho.ViewModels;

namespace Centrabaho.Views.ContentPages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();

	}

    private void OnTogglePasswordVisibility(object sender, CheckedChangedEventArgs e)
    {
        passwordEntry.IsPassword = !e.Value;
        // Optionally change the toggle button content based on e.Value
    }
}