using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Customer
    {
        protected Customer() { }
        public Customer(string fullName, string document, DateTime birthDate)
        {
            FullName = fullName;
            Document = document;
            BirthDate = birthDate;

            Orders = new List<Order>();
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }

        public List<Order> Orders { get; private set; }

        public void Purchase(Order order)
        {
            Orders.Add(order);
        }
    }
}
