using Centrabaho.Models;
using Centrabaho.Services;

namespace Centrabaho.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editUserId;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listView.ItemsSource = await _dbService.GetUsers());
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if (_editUserId == 0)
            {
                // Add Customer

                await _dbService.Create(new UserData
                {
                    FirstName = firstnameEntryField.Text,
                    LastName = lastnameEntryField.Text,
                    Username = usernameEntryField.Text,
                    Email = emailEntryField.Text,
                    Password = passwordEntryField.Text
                });
            }
            else
            {
                // Edit Customer

                await _dbService.Update(new UserData
                {
                    UserId = _editUserId,
                    FirstName = firstnameEntryField.Text,
                    LastName = lastnameEntryField.Text,
                    Username = usernameEntryField.Text,
                    Email = emailEntryField.Text,
                    Password = passwordEntryField.Text
                });

                _editUserId = 0;

                firstnameEntryField.Text = string.Empty;
                lastnameEntryField.Text = string.Empty;
                usernameEntryField.Text = string.Empty;
                emailEntryField.Text = string.Empty;
                passwordEntryField.Text = string.Empty;

            }

            

            listView.ItemsSource = await _dbService.GetUsers();
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var user = (UserData)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":

                    _editUserId = user.UserId;
                    firstnameEntryField.Text = user.FirstName;
                    lastnameEntryField.Text = user.LastName;
                    usernameEntryField.Text = user.Username;
                    emailEntryField.Text = user.Email;
                    passwordEntryField.Text = user.Password;

                    break;
                case "Delete":

                    await _dbService.Delete(user);
                    listView.ItemsSource = await _dbService.GetUsers();

                    break;
            }
        }
    }

}
