using Centrabaho.ViewModels;

namespace Centrabaho.Views;

public partial class CreatePostPage : ContentPage
{
	public CreatePostPage()
	{
        var viewmodel = new CreatePostViewModel();
        BindingContext = viewmodel;
		InitializeComponent();
	}

    private void createPostBtn_Create(object sender, EventArgs e)
    {
        _ = navigateTo("homepage");
    }

    private async Task navigateTo(string url)
    {
        await Shell.Current.GoToAsync(url);
    }

    private void createpostBtn(object sender, EventArgs e)
    {
        _ = navigateTo("createpostpage");
    }

    private void profilepageBtn(object sender, EventArgs e)
    {
        _ = navigateTo("profilepage");
    }

    private void homepageBtn(object sender, EventArgs e)
    {
        _ = navigateTo("homepage");
    }
}