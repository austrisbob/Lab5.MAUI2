using CommunityToolkit.Maui;
using Lab5.MAUI2;
using Microsoft.Extensions.Logging;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Services;


namespace Lab5.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddScoped<IDepartmentApiClient, DepartmentApiClient>();
            builder.Services.AddScoped<IDataRepository, ApiDataRepository>();
            builder.Services.AddSingleton<MainPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
