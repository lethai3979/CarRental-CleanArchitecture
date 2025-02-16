using Domain.CarTypes;
using Domain.Companies;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer
{
    public class ApplicationDbContextSeed
    {

        public static async Task SeedDataAsync(ApplicationDbContext context)
        { 
            await SeedRolesAsync(context);
            await SeedCarTypesAsync(context);
            await SeedCompaniesAsync(context);
        }

        private static async Task SeedRolesAsync(ApplicationDbContext context)
        {
            var roles = Role.AllDomainRoles;
            if (!await context.Roles.AnyAsync())
            {
                foreach (var role in roles)
                {
                    await context.Roles.AddAsync(new IdentityRole(role));
                }
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedCompaniesAsync(ApplicationDbContext context)
        {
            if (!await context.Companies.AnyAsync())
            {
                await context.Companies.AddRangeAsync(new List<Company>
                {
                    new Company(new CompanyId(Guid.NewGuid()), "Toyota"),
                    new Company(new CompanyId(Guid.NewGuid()), "Honda"),
                    new Company(new CompanyId(Guid.NewGuid()), "Suzuki"),
                    new Company(new CompanyId(Guid.NewGuid()), "KIA"),
                    new Company(new CompanyId(Guid.NewGuid()), "Mazda")
                });
                await context.SaveChangesAsync();
            }
        }
        private static async Task SeedCarTypesAsync(ApplicationDbContext context)
        {
            if (!await context.CarTypes.AnyAsync())
            {
                await context.CarTypes.AddRangeAsync(new List<CarType>
                {
                    new CarType(new CarTypeId(Guid.NewGuid()), "SUV"),
                    new CarType(new CarTypeId(Guid.NewGuid()), "Sedan"),
                    new CarType(new CarTypeId(Guid.NewGuid()), "Hatchback"),
                    new CarType(new CarTypeId(Guid.NewGuid()), "Convertible")
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
