using VehicleInventory.Views;

namespace VehicleInventory;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(CarDetailsPage),typeof(CarDetailsPage));
	}
}
