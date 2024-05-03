using Centrabaho.Views;

namespace Centrabaho
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("mainpage", typeof(MainPage));
            Routing.RegisterRoute("loginpage", typeof(LoginPage));
            Routing.RegisterRoute("registerpage", typeof(RegisterPage));
        }
    }
}
