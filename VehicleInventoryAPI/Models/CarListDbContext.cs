using Microsoft.EntityFrameworkCore;

namespace VehicleInventoryAPI.Models
{
    public class CarListDbContext : DbContext
    {
        public CarListDbContext(DbContextOptions<CarListDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Make = "Honda",
                    Model = "City",
                    Vin = "One"
                },

                  new Car
                  {
                      Id = 2,
                      Make = "Nissan",
                      Model = "Altima",
                      Vin = "Two"
                  },
                    new Car
                    {
                        Id = 3,
                        Make = "Toyota",
                        Model = "Fortuner",
                        Vin = "Three"
                    },
                      new Car
                      {
                          Id = 4,
                          Make = "Suzuki",
                          Model = "Jimny",
                          Vin = "Four"
                      },
                        new Car
                        {
                            Id = 5,
                            Make = "Kia",
                            Model = "Seltos",
                            Vin = "Five"
                        },
                          new Car
                          {
                              Id = 6,
                              Make = "Hyundai",
                              Model = "City",
                              Vin = "Six"
                          },
                            new Car
                            {
                                Id = 7,
                                Make = "Mahindra",
                                Model = "Bolero",
                                Vin = "7"
                            }
                );
        }
    }
}
