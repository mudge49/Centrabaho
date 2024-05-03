using Centrabaho.Models;
using Centrabaho.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Centrabaho.ViewModels
{
    public class RegisterViewModel : BindableObject
    {
        private string _firstName;
        public string FirstName
        { 
            get
            {
                return _firstName;
            }

            set
            { 
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;
        public string LastName 
        { 
            get
            {
                return _lastName;
            }

            set
            { 
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private string _username;
        public string Username 
        { 
            get
            {
                return _username;
            }    
            
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email 
        { 
            get 
            { 
                return _email; 
            } 
            set
            {
                _email = value; 
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password 
        { 
            get 
            { 
                return _password; 
            } 
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        { 
            get
            {
                return _confirmPassword;
            }

            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnSignUp);
        }

        //Registers the user and creates a record in the database
        public async void OnSignUp()
        {
            if (_password == string.Empty && _confirmPassword == string.Empty)
            {
                await Shell.Current.DisplayAlert("Error", "Please input a password", "Okay");
                return;
            }
            else if (_password == _confirmPassword)
            {
                await new LocalDbService().Create(new UserData
                {
                    FirstName = _firstName,
                    LastName = _lastName,
                    Username = _username,
                    Email = _email,
                    Password = _password
                });
                await Shell.Current.GoToAsync("//loginpage");
                return;
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Password does not match", "Okay");
            }

        }


    }
}
