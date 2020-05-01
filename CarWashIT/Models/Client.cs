using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashIT.Models
{
    public class Client
    {

        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Remote(action: "VerifyEmail", controller: "Clients")]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Car> Cars { get; set; }

        
    }
}
