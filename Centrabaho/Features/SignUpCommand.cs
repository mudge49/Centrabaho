using Centrabaho.Commands;
using Centrabaho.ViewModels;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrabaho.Features
{
    public class SignUpCommand : AsyncCommandBase
    {
        private readonly SignUpFormViewModel _viewModel;
        private readonly FirebaseAuthClient _authClient;

        public SignUpCommand(SignUpFormViewModel viewModel, FirebaseAuthClient authClient)
        {
            _viewModel = viewModel;
            _authClient = authClient;
        } 

        protected override async Task ExecuteAsync(object parameter)
        {
            if(_viewModel.Password != _viewModel.ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password and Confirm Password do not match", "Okay");
                return;
            }

            try
            {
                await _authClient.CreateUserWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);
                await Application.Current.MainPage.DisplayAlert("Succes", "Signup Successful", "Okay");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error","Failed to Signup", "Okay");
            }
        }
    }
}
