using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Models;
using VehicleInventory.Services;
using VehicleInventory.Views;

namespace VehicleInventory.ViewModels
{
    public partial class CarListViewModel : BaseViewModel
    {
        private readonly CarService carService;
        const string editButtontext = "Update Car";
        const string createButtontext = "Add Car";
        public ObservableCollection<Car> Cars { get; private set; } = new();
        public CarListViewModel()
        {
            Title = "Vehicle Inventory";
            AddEditButtonText = editButtontext;
            GetCarList().Wait();
        }
        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string make;

        [ObservableProperty]
        string model;

        [ObservableProperty]
        string vin;

        [ObservableProperty]
        string addEditButtonText;

        [ObservableProperty]
        int carId;

        [RelayCommand]
        async Task GetCarList()
        {
            if (IsLoading)
                return;

            try
            {
                IsLoading = true;

                if (Cars.Any())
                    Cars.Clear();

                var cars = App.CarService.GetCars();
                foreach (var car in cars)
                {
                    Cars.Add(car);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get cars: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to get vehicle data", "Ok");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        //navigate to car details
        async Task GetCarDetails(int id)
        {
            if (id == 0)
                return;
            await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?Id={id}", true);

        }

        [RelayCommand]
        async Task AddCar()
        {
            if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok");
                return;
            }

            var car = new Car
            {
                Make = Make,
                Model = Model,
                Vin = Vin
            };

            App.CarService.AddCar(car);
            await Shell.Current.DisplayAlert("Info", App.CarService.StatusMessage, "Ok");
            await GetCarList();

        }

        [RelayCommand]
        async Task DeleteCar(int id)
        {
            if (id == 0)
            {
                await Shell.Current.DisplayAlert("invalid Record", "Please try again", "Ok");
                return;
            }
            var result = App.CarService.DeleteCar(id);
            if (result == 0)
                await Shell.Current.DisplayAlert("invalid Data", "Please insert valid data", "Ok");
            else
            {
                await Shell.Current.DisplayAlert("Deletion Successful", "Record Removed Successfully", "Ok");
                await GetCarList();
            }
        }


        [RelayCommand]
        async Task ClearForm()
        {
            AddEditButtonText = createButtontext;
            CarId = 0;
            Make = string.Empty; Model = string.Empty;Vin = string.Empty;
        }


            [RelayCommand]
        async Task SetEditMode(int id)
        {
            AddEditButtonText = editButtontext;
            CarId = id;
            var car = App.CarService.GetCar(id);
            Make = car.Make;
            Model = car.Model;
            Vin = car.Vin;
        }

        [RelayCommand]
        async Task SaveCar()
        {
            if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok");
                return;
            }

            var car = new Car
            {
                Make = Make,
                Model = Model,
                Vin = Vin
            };

            if (CarId != 0)
            {
                car.Id = CarId;
                App.CarService.UpdateCar(car);
                await Shell.Current.DisplayAlert("Info", App.CarService.StatusMessage, "Ok");

            }
            else
            {
                App.CarService.AddCar(car);
                await Shell.Current.DisplayAlert("Info", App.CarService.StatusMessage, "Ok");
            }

            await GetCarList();
            await ClearForm();

        }
    }

}
