﻿using Microsoft.Extensions.Logging;
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
                

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
