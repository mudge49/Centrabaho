using Centrabaho.Views;

namespace Centrabaho
{
    public partial class App : Application
    {
        public static int CurrentUserId;

        public App()
        { 
            InitializeComponent();
            MainPage = new AppShell();
        }

        //Directs to the page of when app starts. adminpage for admin, loginpage for everyone else
        protected override async void OnStart()
        {
            await Shell.Current.GoToAsync("//loginpage");
            //await Shell.Current.GoToAsync("//adminpage");
            
            base.OnStart();
        }
    }
}
