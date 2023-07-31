using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using VehicleInventoryAPI.Models;

namespace VehicleInventoryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowAll", a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

          //  var dbPath = Path.Join(Directory.GetCurrentDirectory(), "carlist.db");
            var conn = new SqliteConnection($"Data Source=D:\\Ashish\\Projects\\VehicleInventory\\VehicleInventoryAPI\\carlist.db");
            builder.Services.AddDbContext<CarListDbContext>(a => a.UseSqlite(conn));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthorization();


            app.MapGet("/cars", async (CarListDbContext db) => await db.Cars.ToListAsync());

            app.MapGet("/cars/{id}", async (int id, CarListDbContext db) =>
            await db.Cars.FindAsync(id) is Car car ? Results.Ok(car) : Results.NotFound()
               );

            app.MapPut("/cars/{id}", async (int id, Car car, CarListDbContext db) =>
            {
                var record = await db.Cars.FindAsync(id);
                if (record is null) return Results.NotFound();

                record.Make = car.Make;
                record.Model = car.Model;
                record.Vin = car.Vin;

                await db.SaveChangesAsync();

                return Results.NoContent();

            });

            app.MapDelete("/cars/{id}", async (int id, CarListDbContext db) => {
                var record = await db.Cars.FindAsync(id);
                if (record is null) return Results.NotFound();
                db.Remove(record);
                await db.SaveChangesAsync();

                return Results.NoContent();

            });

            app.MapPost("/cars", async (Car car, CarListDbContext db) => {
                await db.AddAsync(car);
                await db.SaveChangesAsync();

                return Results.Created($"/cars/{car.Id}", car);

            });


            app.Run();
        }
    }
}