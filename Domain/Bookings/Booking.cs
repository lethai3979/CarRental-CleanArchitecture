using Domain.Cars;
using Domain.Promotions;
using Domain.Shared;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bookings
{
    public class Booking : BaseEntity<BookingId>
    {

        private Booking(BookingId id,
                        decimal totalPrice,
                        DateTime recieveDate,
                        DateTime returnDate,
                        BookingStatus status,
                        CarId carId,
                        string userId,
                        PromotionId promotionId) : base(id)
        {
            TotalPrice = totalPrice;
            RecieveDate = recieveDate;
            ReturnDate = returnDate;
            Status = status;
            CarId = carId;
            PromotionId = promotionId;
            UserId = userId;
        }

        public decimal TotalPrice { get; private set; }
        public DateTime RecieveDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public BookingStatus Status { get; private set; }
        public CarId CarId { get; private set; }
        public PromotionId PromotionId { get; private set; }
        public string UserId { get; private set; }
        public static Booking Create(BookingId id,
                                    decimal totalPrice,
                                    DateTime recieveDate,
                                    DateTime returnDate,
                                    CarId carId,
                                    string userId,
                                    PromotionId promotionId = null!)
        {
            if (totalPrice <= 0)
            {
                throw new InvalidDataException("Total price must be greater than 0");
            }
            if (recieveDate < DateTime.Now)
            {
                throw new InvalidDataException("Recieve date must be in the future");
            }
            if (recieveDate >= returnDate)
            {
                throw new InvalidDataException("Recieve date must be greater than current date");
            }

            if (carId is null)
            {
                throw new NullReferenceException("Car must not be null");
            }
            if (userId is null)
            {
                throw new NullReferenceException("User must not be null");
            }
            return new Booking(id, totalPrice, recieveDate, returnDate, BookingStatus.Pending, carId, userId, promotionId);
        }

        public void UpdateStatus(BookingStatus newStatus)
        {
            if(Status == BookingStatus.Cancelled)
            {
                throw new InvalidOperationException("Cannot change status of a cancelled booking.");
            }
            if(RecieveDate < DateTime.Now && DateTime.Now < ReturnDate && newStatus != BookingStatus.Ongoing)
            {
                throw new InvalidOperationException("Cannot change status of an ongoing booking.");
            }
            Status = newStatus;
        }

        public void ApplyPromotion(Promotion promotion)
        {
            if(promotion is null)
            {
                throw new NullReferenceException("Promotion must not be null");
            }
            if(promotion.ExpireDate < DateTime.Now)
            {
                throw new InvalidDataException("Promotion has expired");
            }
            PromotionId = promotion.Id;
        }

        public void UpdateDates(DateTime newRecieveDate, DateTime newReturnDate)
        {
            if (newRecieveDate < DateTime.Now)
            {
                throw new InvalidDataException("Recieve date must be in the future");
            }
            if (newRecieveDate >= newReturnDate)
            {
                throw new ArgumentException("Recieve date must be earlier than return date.");
            }

            RecieveDate = newRecieveDate;
            ReturnDate = newReturnDate;
        }
    }
}
