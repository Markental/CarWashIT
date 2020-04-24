using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashIT.Models
{
    public class Order
    {
        public int Id { get; set; }
        public float Price { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime DeadLine { get; set; }

        public IList<OrderCar> OrderCars { get; set; }
    }
}
