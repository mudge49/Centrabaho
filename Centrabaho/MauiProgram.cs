using Centrabaho.ViewModels;
using Centrabaho.Views.ContentPages;
using Centrabaho.Views.ContentViews;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UraniumUI;

namespace Centrabaho
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFontAwesomeIconFonts();
                    fonts.AddMaterialIconFonts();
                    
                })
                .UseUraniumUI()
                .UseUraniumUIMaterial();

            builder.Services.AddTransient<SignUpFormViewModel>();
            builder.Services.AddTransient<SignUpViewModel>();
            builder.Services.AddTransient<SignUpPage>(
                s => new SignUpPage(s.GetRequiredService<SignUpViewModel>()));

            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBaizcJJzd6Sv1zumni-Zs0J98TytO78qc",
                AuthDomain = "centrabaho.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));
                

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
