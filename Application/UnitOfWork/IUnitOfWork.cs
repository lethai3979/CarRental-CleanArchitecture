using Domain.Bookings;
using Domain.Cars;
using Domain.CarTypes;
using Domain.Companies;
using Domain.Invoices;
using Domain.Promotions;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        IBookingRepository BookingRepository { get; }
        IPromotionRepository PromotionRepository { get; }
        ICarTypeRepository CarTypeRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IUserRepository UserRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        void SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
