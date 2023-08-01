using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VehicleInventory.Models;
using VehicleInventory.Services;

namespace VehicleInventory.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class CarDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly CarApiService carApiService;

        public CarDetailsViewModel(CarApiService carApiService)
        {
            this.carApiService = carApiService;
        }

        NetworkAccess accessType = Connectivity.Current.NetworkAccess; 

        [ObservableProperty]
        Car car;

        [ObservableProperty]
        int id;


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
            //Car = App.CarService.GetCar(Id);
        }

        public async Task GetCarData()
        {
            if(accessType==NetworkAccess.Internet)
            {
                Car = await carApiService.GetCar(Id);
            }
            else
            {
                Car = App.CarService.GetCar(Id);
            }
        }
    }
}
