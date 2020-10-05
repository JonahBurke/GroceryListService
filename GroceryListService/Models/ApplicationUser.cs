using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _GroceryListService.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }

        public string nickname { get; set; }

        public string emailAddress { get; set; }

        public string Password { get; set; }

    }
}
