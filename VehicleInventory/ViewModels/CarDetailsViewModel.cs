using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Models;

namespace VehicleInventory.ViewModels
{
    [QueryProperty(nameof(Car), "Car")]
    public partial class CarDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Car car;

        //public CarDetailsViewModel()
        //{
        //    Title = $"Car Details -  {car.Make} {car.Model} ";
        //}
    }
}
