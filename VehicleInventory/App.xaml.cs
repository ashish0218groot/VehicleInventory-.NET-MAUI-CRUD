using VehicleInventory.Services;

namespace VehicleInventory;

public partial class App : Application
{
	public static CarDatabaseService CarService { get; private set; }
	public App(CarDatabaseService carService)
	{
		InitializeComponent();

		MainPage = new AppShell();
		CarService = carService;
	}
}
