using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashIT.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }

        //One-to-Many
        public int ClientId { get; set; }
        public Client Client { get; set; }

        //One-to-One
        public CarNumber CarNumber { get; set;}

        //Many-to-Many
        public IList<OrderCar> OrderCars { get; set; }
    }
}
