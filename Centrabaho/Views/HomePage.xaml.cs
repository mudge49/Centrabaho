using Centrabaho.ViewModels;

namespace Centrabaho.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            var viewmodel = new HomeViewModel();
            BindingContext = viewmodel;
            viewmodel.HomeCommand.Execute(null);
        }

        private async Task navigateTo(string url)
        {
            await Shell.Current.GoToAsync(url);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _ = navigateTo("createpostpage");
        }
    }

}
