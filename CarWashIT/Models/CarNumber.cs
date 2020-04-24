using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashIT.Models
{
    public class CarNumber
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }

        //One-to-One
        public int CarId { get; set; }
        public Car car;
    }
}
