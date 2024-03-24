using Microsoft.Extensions.Logging;
using MiracleLandCrossPlatform.ViewModel;

namespace MiracleLandCrossPlatform
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
                });
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ProductViewModel>();

            builder.Services.AddTransient<CustomerShell>();
            builder.Services.AddTransient<AdminShell>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
