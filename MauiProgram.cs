using CityScapeApp.Objects;
using CityScapeApp.Viewmodels;
using CityScapeApp.Views;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using CommunityToolkit.Maui;
using Plugin.Maui.Audio;

namespace CityScapeApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            MauiAppBuilder mauiAppBuilder = 
                builder.UseMauiApp<App>().UseSkiaSharp().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkitMediaElement();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<CityscapeStreets>();
            builder.Services.AddSingleton<CityscapeStreetsViewModel>();
            builder.Services.AddSingleton<LivingRoomPage>();
            builder.Services.AddSingleton<LivingRoomPageViewmodel>();
            //builder.Services.AddSingleton(AudioManager.Current);

            var app = builder.Build();
            ServiceHelper.Initialize(app.Services);
            return app;
        }
    }
}