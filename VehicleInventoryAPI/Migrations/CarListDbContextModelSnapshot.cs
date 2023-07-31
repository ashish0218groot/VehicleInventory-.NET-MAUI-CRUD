﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleInventoryAPI.Models;

#nullable disable

namespace VehicleInventoryAPI.Migrations
{
    [DbContext(typeof(CarListDbContext))]
    partial class CarListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4");

            modelBuilder.Entity("VehicleInventoryAPI.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Make = "Honda",
                            Model = "City",
                            Vin = "One"
                        },
                        new
                        {
                            Id = 2,
                            Make = "Nissan",
                            Model = "Altima",
                            Vin = "Two"
                        },
                        new
                        {
                            Id = 3,
                            Make = "Toyota",
                            Model = "Fortuner",
                            Vin = "Three"
                        },
                        new
                        {
                            Id = 4,
                            Make = "Suzuki",
                            Model = "Jimny",
                            Vin = "Four"
                        },
                        new
                        {
                            Id = 5,
                            Make = "Kia",
                            Model = "Seltos",
                            Vin = "Five"
                        },
                        new
                        {
                            Id = 6,
                            Make = "Hyundai",
                            Model = "City",
                            Vin = "Six"
                        },
                        new
                        {
                            Id = 7,
                            Make = "Mahindra",
                            Model = "Bolero",
                            Vin = "7"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}