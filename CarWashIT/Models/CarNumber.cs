using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashIT.Models
{
    public class CarNumber
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Number { get; set; }

        //One-to-One
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
