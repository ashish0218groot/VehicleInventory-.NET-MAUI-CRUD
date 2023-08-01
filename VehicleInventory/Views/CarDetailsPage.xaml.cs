using VehicleInventory.ViewModels;

namespace VehicleInventory.Views;

public partial class CarDetailsPage : ContentPage
{
    private readonly CarDetailsViewModel carDetailsViewModel;

    public CarDetailsPage(CarDetailsViewModel carDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = carDetailsViewModel;
        this.carDetailsViewModel = carDetailsViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await carDetailsViewModel.GetCarData();
    }


    //public CarDetailsPage(CarDetailsViewModel carDetailsViewModel)
    //{
    //	InitializeComponent();
    //	BindingContext = carDetailsViewModel;
    //}

    //   protected override void OnNavigatedTo(NavigatedToEventArgs args)
    //   {
    //       base.OnNavigatedTo(args);
    //   }
}