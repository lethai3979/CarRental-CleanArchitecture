using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public static class Role
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        public const string Employee = "Employee";

        public static readonly List<string> AllDomainRoles = new List<string>() { Admin, Customer, Employee};
    }
}
