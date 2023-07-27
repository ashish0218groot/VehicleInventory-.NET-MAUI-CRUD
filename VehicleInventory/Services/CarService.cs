using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Models;

namespace VehicleInventory.Services
{
    public class CarService
    {
        public List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car
                {
                    Id=1, Make="Maruti Suzuki",Model="Invicto",Vin="1"
                },

                new Car
                {
                    Id=2, Make="Hyundai",Model="Tucson",Vin="2"
                },

                new Car
                {
                    Id=3, Make="Toyota",Model="Land Cruiser",Vin="3"
                },

                new Car
                {
                    Id=4, Make="Nissan",Model="magnite",Vin="4"
                },

                new Car
                {
                    Id=5, Make="Renault",Model="Kiger",Vin="5"
                },

                new Car
                {
                    Id=6, Make="Kia",Model="Carens",Vin="6"
                },

                new Car
                {
                    Id=7, Make="Mahindra",Model="XUV700",Vin="7"
                },           

            };
        }
    }
}
