using Domain.CarTypes;
using Domain.Companies;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cars
{
    public class Car : BaseEntity<CarId>
    {

        private Car(CarId id, string name, int seat, decimal price, CarTypeId carTypeId, CompanyId companyId) : base(id)
        {
            Name = name;
            Seat = seat;
            Price = price;
            CarTypeId = carTypeId;
            CompanyId = companyId;
        }

        public string Name { get; private set; } = string.Empty;
        public int Seat { get; private set; }
        public decimal Price { get; private set; }
        public CarTypeId CarTypeId { get; private set; }
        public CompanyId CompanyId { get; private set; }

        public static Car Create(string name, int seat, decimal price, CarTypeId carTypeId, CompanyId companyId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name is empty");
            }
            if (seat <= 0)
            {
                throw new ArgumentOutOfRangeException("Seat is negative number");
            }
            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException("Price is negative number");
            }
            return new Car(new CarId(Guid.NewGuid()), name, seat, price, carTypeId, companyId);
        }

        public void Update(string name, int seat, decimal price, CarTypeId carTypeId, CompanyId companyId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name is empty");
            }
            if (seat <= 0)
            {
                throw new ArgumentOutOfRangeException("Seat is negative number");
            }
            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException("Price is negative number");
            }
            Name = name;
            Seat = seat;
            Price = price;
            CarTypeId = carTypeId;
            CompanyId = companyId;
        }
    }
}
