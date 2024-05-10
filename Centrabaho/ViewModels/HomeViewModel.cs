using Centrabaho.Models;
using Centrabaho.Services;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace Centrabaho.ViewModels
{
    public class HomeViewModel : BindableObject
    {

        public ObservableCollection<PostData> Posts
        {
            get => (ObservableCollection<PostData>)GetValue(PostsProperty);
            set => SetValue(PostsProperty, value);
        }

        public static readonly BindableProperty PostsProperty =
            BindableProperty.Create(nameof(Posts), typeof(ObservableCollection<PostData>), typeof(HomeViewModel), new ObservableCollection<PostData>());

        public ICommand HomeCommand { get; private set; }
        public ICommand SignOutCommand { get;}
        public ICommand CopyContactNumberCommand { get; private set; }
        public ICommand CopyEmailCommand { get; private set; }

        public HomeViewModel()
        {
            HomeCommand = new Command(async () => await LoadPosts());
            SignOutCommand = new Command(async () => await OnLogout()); 
            CopyContactNumberCommand = new Command(async (contactNumber) => await CopyContactNumber(contactNumber));
            CopyEmailCommand = new Command(async (email) => await CopyEmail(email));
        }

        public async Task LoadPosts()
        {
            var posts = await new LocalDbService().GetPosts();
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

        private async Task CopyContactNumber(object contactNumber)
        {
            var contactStr = contactNumber as string;
            if (!string.IsNullOrEmpty(contactStr))
            {
                await Clipboard.SetTextAsync(contactStr);
            }
            await Shell.Current.DisplayAlert("Contact Number Copied", "Successfully copied contact number", "Okay");
        }

        private async Task CopyEmail(object email)
        {
            var emailStr = email as string;
            if (!string.IsNullOrEmpty(emailStr))
            {
                await Clipboard.SetTextAsync(emailStr);
            }
            await Shell.Current.DisplayAlert("Email Copied", "Successfully copied email adress", "Okay");
        }

        private async Task OnLogout()
        {
            App.CurrentUserId = 0;
            await Shell.Current.GoToAsync("//loginpage"); // Adjust the route based on your routing setup
        }
    }
}
