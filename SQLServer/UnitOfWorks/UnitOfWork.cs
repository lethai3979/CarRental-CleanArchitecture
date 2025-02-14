using Application.UnitOfWork;
using Domain.Bookings;
using Domain.Cars;
using Domain.CarTypes;
using Domain.Companies;
using Domain.Invoices;
using Domain.Primitives;
using Domain.Promotions;
using Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        private readonly IPublisher _publisher;

        public UnitOfWork(ApplicationDbContext context,
            IBookingRepository bookingRepository,
            ICarRepository carRepository,
            ICarTypeRepository carTypeRepository,
            ICompanyRepository companyRepository,
            IPromotionRepository promotionRepository,
            IUserRepository userRepository,
            IInvoiceRepository invoiceRepository,
            IPublisher publisher)
        {
            _context = context;
            BookingRepository = bookingRepository;
            CarRepository = carRepository;
            CarTypeRepository = carTypeRepository;
            CompanyRepository = companyRepository;
            PromotionRepository = promotionRepository;
            UserRepository = userRepository;
            InvoiceRepository = invoiceRepository;
            _publisher = publisher;
        }

        public ICarTypeRepository CarTypeRepository { get; }

        public ICompanyRepository CompanyRepository { get; }

        public IPromotionRepository PromotionRepository { get; }

        public ICarRepository CarRepository { get; }

        public IBookingRepository BookingRepository { get; }
        public IUserRepository UserRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            var eventEntities = _context.ChangeTracker.Entries<BaseEntity<EntityId>>() 
                .Where(e => e.Entity.domainEvents.Any())
                .Select(e => e.Entity)
                .ToList();
            var domainEvents = eventEntities.SelectMany(e => e.domainEvents).ToList();
            var result = await _context.SaveChangesAsync();
            await DispatchDomainEventAsync(eventEntities);
            return result;
        }

        private async Task DispatchDomainEventAsync(List<BaseEntity<EntityId>> eventEntities)
        {
            foreach (var entity in eventEntities)
            {
                foreach (var domainEvent in entity.domainEvents)
                {
                    await _publisher.Publish(domainEvent); // Dùng IPublisher của MediatR
                }
                entity.ClearEvents();
            }
        }
    }
}
