using SQLite;
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
        private SQLiteConnection conn;
        string _dbPath;
        public string StatusMessage;
        public int result = 0;

        public CarService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Car>();
        }

        public void AddCar(Car car)
        {
            try
            {
                Init();

                if (car == null)
                {
                    throw new Exception("Invalid car record");
                }

                result = conn.Insert(car);
                StatusMessage = result == 0 ? "Insert Failed" : "Insert Successful";
            }
            catch (Exception)
            {
                StatusMessage = "Failed to insert Data";        
            }
           
        }

        public int DeleteCar(int id)
        {
            try
            {
                Init();
                return conn.Table<Car>().Delete(a=>a.Id == id);
            }
            catch (Exception)
            {

                StatusMessage = "Failed to delete data";
            }
            return 0;
        }

        public Car GetCar(int id) 
        {
            try
            {
                Init();
                return conn.Table<Car>().FirstOrDefault(a=>a.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to retrieve data";
            }
            return null;
        }


        public List<Car> GetCars()
        {
            try
            {
                Init();
                return conn.Table<Car>().ToList();
            }

            catch
            {
                StatusMessage = "Failed to Retrieve Data";
            }

            return new List<Car>();
        }

        public void UpdateCar (Car car)
        {
            try
            {
                Init();

                if (car == null)
                {
                    throw new Exception("Invalid car record");
                }

                result = conn.Update(car);
                StatusMessage = result == 0 ? "Update Failed" : "Update Successful";
            }
            catch (Exception)
            {
                StatusMessage = "Failed to insert Data";
            }

        }

        //public List<Car> GetCars()
        //{
        //    return new List<Car>()
        //    {
        //        new Car
        //        {
        //            Id=1, Make="Maruti Suzuki",Model="Invicto",Vin="1"
        //        },

        //        new Car
        //        {
        //            Id=2, Make="Hyundai",Model="Tucson",Vin="2"
        //        },

        //        new Car
        //        {
        //            Id=3, Make="Toyota",Model="Land Cruiser",Vin="3"
        //        },

        //        new Car
        //        {
        //            Id=4, Make="Nissan",Model="magnite",Vin="4"
        //        },

        //        new Car
        //        {
        //            Id=5, Make="Renault",Model="Kiger",Vin="5"
        //        },

        //        new Car
        //        {
        //            Id=6, Make="Kia",Model="Carens",Vin="6"
        //        },

        //        new Car
        //        {
        //            Id=7, Make="Mahindra",Model="XUV700",Vin="7"
        //        },

        //    };
        //}
    }
}
