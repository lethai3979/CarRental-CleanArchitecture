using Application.UnitOfWork;
using Domain.Bookings;
using Domain.Cars;
using Domain.CarTypes;
using Domain.Companies;
using Domain.Promotions;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context,
            IBookingRepository bookingRepository,
            ICarRepository carRepository,
            ICarTypeRepository carTypeRepository,
            ICompanyRepository companyRepository,
            IPromotionRepository promotionRepository,
            IUserRepository userRepository)
        {
            _context = context;
            BookingRepository = bookingRepository;
            CarRepository = carRepository;
            CarTypeRepository = carTypeRepository;
            CompanyRepository = companyRepository;
            PromotionRepository = promotionRepository;
            UserRepository = userRepository;
        }

        public ICarTypeRepository CarTypeRepository { get; }

        public ICompanyRepository CompanyRepository { get; }

        public IPromotionRepository PromotionRepository { get; }

        public ICarRepository CarRepository { get; }

        public IBookingRepository BookingRepository { get; }
        public IUserRepository UserRepository { get; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
