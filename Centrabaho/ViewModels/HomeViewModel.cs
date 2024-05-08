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
        public ICommand GoToPostDetailCommand { get; private set; }

        public HomeViewModel()
        {
            HomeCommand = new Command(async () => await LoadPosts());
            SignOutCommand = new Command(async () => await OnLogout());
            GoToPostDetailCommand = new Command<int>(async (postId) => await ViewPost(postId));
        }


        //Retrieves all records from PostData and facilitates the loading of posts
        public async Task LoadPosts()
        {
            var posts = await new LocalDbService().GetPosts(); // Implement this method to fetch from SQLite
            Posts.Clear();
            foreach (var post in posts)
            {
                var user = await new LocalDbService().GetUserById(post.UserId);
                post.Username = user?.Username ?? "Unknown User";
                post.ProfilePictureUrl = user?.ProfileImageUrl ?? "sampleprofile.png";
                Posts.Add(post);
            }
        }

        public async Task OnLogout()
        {
            App.CurrentUserId = 0;
            await Shell.Current.GoToAsync("//loginpage"); // Adjust the route based on your routing setup
        }

        public async Task ViewPost(int postId)
        {
            await Shell.Current.GoToAsync($"postdetailspage?PostId={postId}");
        }
    }
}
