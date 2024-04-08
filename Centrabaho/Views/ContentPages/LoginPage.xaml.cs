using Centrabaho.ViewModels;

namespace Centrabaho.Views.ContentPages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();

	}
}