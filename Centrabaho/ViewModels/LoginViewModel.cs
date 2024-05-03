using Centrabaho.Services;
using System.Windows.Input;

namespace Centrabaho.ViewModels
{
    public class LoginViewModel : BindableObject
    {
        private string _email;
        private string _password;

        public string email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignInCommand { get; }

        public LoginViewModel()
        {
            SignInCommand = new Command(OnSignIn);
        }


        private async void OnSignIn()
        {
            var authenticatedUser = await new LocalDbService().AuthenticateUser(email, password);

            if (authenticatedUser != null)
            {
                await Shell.Current.GoToAsync("//mainpage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Email and/or Password is incorrect.", "Okay");
            }
        }
    }
}
