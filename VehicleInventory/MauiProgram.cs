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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<CarService>();
		builder.Services.AddSingleton<CarListViewModel>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<CarDetailsPage>();
		builder.Services.AddTransient<CarDetailsViewModel>();
		return builder.Build();
	}
}
