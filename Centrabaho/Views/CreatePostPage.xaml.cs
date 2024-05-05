namespace Centrabaho.Views;

public partial class CreatePostPage : ContentPage
{
	public CreatePostPage()
	{
		InitializeComponent();
	}

    private void createPostBtn_Clicked(object sender, EventArgs e)
    {
        _ = navigateTo("homepage");
    }

	private async Task navigateTo(string url)
	{
		await Shell.Current.GoToAsync(url);
	}
}