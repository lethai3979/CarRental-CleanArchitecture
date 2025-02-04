using Domain.Bookings;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class User : IdentityUser
    {
        public required string Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
