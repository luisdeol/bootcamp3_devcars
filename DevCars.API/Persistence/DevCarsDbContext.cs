using DevCars.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Persistence
{
    public class DevCarsDbContext
    {
        public DevCarsDbContext()
        {
            Cars = new List<Car>
            {
                new Car(1, "123ABC", "HONDA", "CIVIC", 2021, 100000, "Cinza", new DateTime(2021, 1, 1)),
                new Car(2, "456ABC", "CHEVROLET", "ONIX", 2021, 95000, "Azul", new DateTime(2021, 1, 1)),
                new Car(3, "789ABC", "HYUNDAI", "HB20", 2021, 85000, "Branco", new DateTime(2021, 2, 1))
            };

            Customers = new List<Customer>
            {
                new Customer(1, "LUCIANO", "1234567", new DateTime(1990, 1, 1)),
                new Customer(2, "GUSTAVO", "1234567", new DateTime(1990, 1, 1)),
                new Customer(3, "GABRIEL", "1234567", new DateTime(1990, 1, 1)),
            };
        }

        public List<Car> Cars { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
