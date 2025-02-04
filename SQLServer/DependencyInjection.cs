using Application.UnitOfWork;
using Domain.Bookings;
using Domain.Cars;
using Domain.CarTypes;
using Domain.Companies;
using Domain.Promotions;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SQLServer.Repositories;
using SQLServer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer
{
    public static class DependencyInjection
    {
        public static void AddSQLServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICarTypeRepository, CarTypeRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
        }
    }
}
