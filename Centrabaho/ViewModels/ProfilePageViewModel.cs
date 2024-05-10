using Centrabaho.Models;
using Centrabaho.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Centrabaho.ViewModels
{
    public class ProfilePageViewModel : BindableObject
    {
        private string _profileImagePath;
        private string _username;
        private int _userId;
        private string _name;
        private string _email;
        private string _contactnumber;

        public string ContactNumber
        {
            get
            {
                return _contactnumber;
            }
            set
            {
                _contactnumber = value;
                OnPropertyChanged();
            }
        }

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

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

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

        public string ProfileImagePath
        {
            get => _profileImagePath;
            set
            {
                _profileImagePath = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PostData> Posts
        {
            get => (ObservableCollection<PostData>)GetValue(PostsProperty);
            set => SetValue(PostsProperty, value);
        }

        public static readonly BindableProperty PostsProperty =
            BindableProperty.Create(nameof(Posts), typeof(ObservableCollection<PostData>), typeof(HomeViewModel), new ObservableCollection<PostData>());

        public ICommand PostCommand;
        public ICommand UploadImageCommand { get; private set; }
        public ICommand SignOutCommand { get; private set; }

        public ProfilePageViewModel()
        {
            UploadImageCommand = new Command(async () => await UploadProfilePicture());
            SignOutCommand = new Command(async () => await OnLogout());
            LoadUserData();
            LoadPosts();
        }

        // Method to load the current user's data
        private async void LoadUserData()
        {
            var dbService = new LocalDbService();
            var user = await dbService.GetUserById(App.CurrentUserId); 
            if (user != null)
            {
                Username = user.Username;
                Name = user.FullName;
                _userId = user.UserId;
                Email = user.Email;
                ContactNumber = user.ContactNumber;
                ProfileImagePath = user.ProfileImageUrl;
            }
        }

        public async Task LoadPosts()
        {
            var posts = await new LocalDbService().GetPostsByUserId(App.CurrentUserId); // Implement this method to fetch from SQLite
            Posts.Clear();
            foreach (var post in posts)
            {
                post.ImagePaths = !string.IsNullOrWhiteSpace(post.SerializedImagePaths)
                    ? post.SerializedImagePaths.Split(';').ToList()
                    : new List<string>();

                // Additional user information assignments (if needed)
                var user = await new LocalDbService().GetUserById(post.UserId);
                post.Username = user?.Username ?? "Unknown User";
                post.ProfilePictureUrl = user?.ProfileImageUrl ?? "sampleprofile.png";
                post.ContactNumber = user?.ContactNumber;
                post.Email = user?.Email;

                Posts.Add(post);
            }
        }

        private async Task UploadProfilePicture()
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Select Profile Picture"
                });

                if (result != null)
                {
                    var destinationPath = Path.Combine(FileSystem.AppDataDirectory, result.FileName);

                    using (var stream = await result.OpenReadAsync())
                    using (var destStream = File.Create(destinationPath))
                    {
                        await stream.CopyToAsync(destStream);
                    }

                    ProfileImagePath = destinationPath;

                    var dbService = new LocalDbService();
                    var user = await dbService.GetUserById(_userId);
                    if (user != null)
                    {
                        user.ProfileImageUrl = destinationPath;
                        await dbService.Update(user);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error picking file: {ex.Message}");
            }
        }

        private async Task OnLogout()
        {
            App.CurrentUserId = 0;
            await Shell.Current.GoToAsync("//loginpage"); // Adjust the route based on your routing setup
        }

    }
}

