using Centrabaho.ViewModels;
using System.Xml.Serialization;

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

        private void createpostBtn(object sender, EventArgs e)
        {
            _ = navigateTo("createpostpage");
        }
    }

}
