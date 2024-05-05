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

        public HomeViewModel()
        {
            HomeCommand = new Command(async () => await LoadPosts());
        }


        //Retrieves all records from PostData and facilitates the loading of posts
        public async Task LoadPosts()
        {
            var posts = await new LocalDbService().GetPosts(); // Implement this method to fetch from SQLite
            Posts.Clear();
            foreach (var post in posts)
            {
                var user = await new LocalDbService().GetUserById(post.UserId);
                post.Username = user.Username;
                Posts.Add(post);
            }
        }
    }
}
