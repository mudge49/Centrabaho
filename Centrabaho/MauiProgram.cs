using Centrabaho.Services;
using Centrabaho.ViewModels;
using Centrabaho.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

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
                fonts.AddFont("TheBoldFont.ttf", "TheBoldFont-ttf");
                fonts.AddFont("TheBoldFont.otf", "TheBoldFont-otf");

            }).UseMauiCommunityToolkit();
            builder.Services.AddSingleton<LocalDbService>();

            builder.Services.AddTransient<CreatePostPage>();
            builder.Services.AddTransient<CreatePostViewModel>();

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<HomeViewModel>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginViewModel>();

            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<RegisterViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}