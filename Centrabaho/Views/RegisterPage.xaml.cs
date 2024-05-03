namespace Centrabaho.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
        InitializeComponent();
	}

    //Toggles password visibility
    private void passwordBtn_Clicked(object sender, EventArgs e)
    {
        if(passwordEntry.IsPassword)
        {
            passwordEntry.IsPassword = false;
            passwordBtn.ImageSource = "password_shown.png";
            return;
        }
        passwordEntry.IsPassword = true;
        passwordBtn.ImageSource = "password_hidden.png";
    }

    private void confirmPasswordBtn_Clicked(object sender, EventArgs e)
    {
        if(confirmPasswordEntry.IsPassword)
        { 
            confirmPasswordEntry.IsPassword = false;
            confirmPasswordBtn.ImageSource = "password_shown.png";
            return;
        }
        confirmPasswordEntry.IsPassword = true;
        confirmPasswordBtn.ImageSource = "password_hidden.png";
    }
}