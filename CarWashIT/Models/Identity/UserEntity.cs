using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashIT.Models.Identity
{
    public class UserEntity : IdentityUser
    {
        public UserEntity()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
