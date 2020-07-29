using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.Data
{
    public class SammysAutoUser : IdentityUser
    {
        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string Address { get; set; }

        
        public string City { get; set; }

       
        public string PostalCode { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool isAdmin { get; set; }

    }

    public class SammysAutoRole : IdentityRole
    {
        public SammysAutoRole(string roleName) : base(roleName)
        {
        }
    }
}
