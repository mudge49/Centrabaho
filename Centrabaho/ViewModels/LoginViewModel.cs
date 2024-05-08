using Centrabaho.Services;
using System.Windows.Input;

namespace Centrabaho.ViewModels
{
    public class LoginViewModel : BindableObject
    {
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
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
            if(_password != null || _password != string.Empty)
            {
                _password = string.Empty;
            }

            if(_username != null || _username != string.Empty)
            {
                _username = string.Empty;
            }
        }

        //Signing-In authentication. Exectued after button click
        private async void OnSignIn()
        {
            var authenticatedUser = await new LocalDbService().AuthenticateUser(Username, Password);

            if (authenticatedUser != null)
            {
                await Shell.Current.GoToAsync("homepage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Email and/or Password is incorrect.", "Okay");
            }
        }
    }
}
