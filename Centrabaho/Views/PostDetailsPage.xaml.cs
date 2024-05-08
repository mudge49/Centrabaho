using Centrabaho.Services;

namespace Centrabaho.Views;

[QueryProperty(nameof(PostId), "postId")]
public partial class PostDetailsPage : ContentPage
{
    private int postId;
    public int PostId
    {
        get => postId;
        set
        {
            postId = value;
            LoadPostDetails(value);
        }
    }

    public PostDetailsPage()
    {
        InitializeComponent();
    }

    private async Task LoadPostDetails(int postId)
    {
        var post = await new LocalDbService().GetPostsByUserId(postId);
        BindingContext = post;  
    }
}