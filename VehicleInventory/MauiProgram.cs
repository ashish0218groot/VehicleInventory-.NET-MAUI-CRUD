using Microsoft.Extensions.Logging;
using VehicleInventory.Services;
using VehicleInventory.ViewModels;
using VehicleInventory.Views;

namespace VehicleInventory;

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

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "cars.db3");

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton(a => ActivatorUtilities.CreateInstance<CarDatabaseService>(a, dbPath));

        builder.Services.AddSingleton<CarListViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<CarDetailsPage>();
        builder.Services.AddTransient<CarDetailsViewModel>();
        builder.Services.AddTransient<CarApiService>();
        return builder.Build();
    }
}
