using Centrabaho.Views;

namespace Centrabaho
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("homepage", typeof(HomePage));
            Routing.RegisterRoute("loginpage", typeof(LoginPage));
            Routing.RegisterRoute("registerpage", typeof(RegisterPage));
            Routing.RegisterRoute("createpostpage", typeof(CreatePostPage));
            Routing.RegisterRoute("adminpage", typeof(AdminPage));

        }
    }
}
