using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.ViewModels
{
    public class CarDetailsViewModel
    {
        public CarDetailsViewModel(int id, string brand, string model, string vinCode, int year, decimal price, string color, DateTime productionDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            VinCode = vinCode;
            Year = year;
            Price = price;
            Color = color;
            ProductionDate = productionDate;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string VinCode { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
