using Centrabaho.Services;
using System.Windows.Input;

namespace Centrabaho.ViewModels
{
    public class LoginViewModel : BindableObject
    {
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignInCommand { get; }

        //Assigns the SignInCommand to be executed
        public LoginViewModel()
        {
            SignInCommand = new Command(OnSignIn);
        }

        //Signing-In authentication. Exectued after button click
        private async void OnSignIn()
        {
            var authenticatedUser = await new LocalDbService().AuthenticateUser(Email, Password);

            if (authenticatedUser != null)
            {
                await Shell.Current.DisplayAlert("Success", "Login Successful", "Okay");
                await Shell.Current.GoToAsync("homepage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Email and/or Password is incorrect.", "Okay");
            }
        }
    }
}
