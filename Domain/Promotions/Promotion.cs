using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Promotions
{
    public class Promotion : BaseEntity<PromotionId>
    {

        private Promotion(PromotionId id, string content, double discountValue, DateTime startDate, DateTime expireDate) : base(id)
        {
            Content = content;
            DiscountValue = discountValue;
            StartDate = startDate;
            ExpireDate = expireDate;
        }

        public string Content { get; private set; } = string.Empty;
        public double DiscountValue { get; private set; }
        public DateTime StartDate { get; private set; } = DateTime.Now;
        public DateTime ExpireDate { get; private set; }

        public static Promotion Create(PromotionId id, string content, double discountValue, DateTime startDate ,DateTime expireDate)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException("Content must not be empty");
            }
            if (discountValue <= 0)
            {
                throw new InvalidDataException("Discount value must be greater than 0");
            }
            if (startDate < DateTime.Now)
            {
                throw new InvalidDataException("Start date is in the past");
            }
            if(expireDate < startDate)
            {
                expireDate = startDate.AddDays(1);
            }
            return new Promotion(id, content, discountValue, startDate, expireDate);
        }

        public void UpdateInfomation(string content, double discountValue)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException("Content must not be empty");
            }
            if (discountValue <= 0)
            {
                throw new InvalidDataException("Discount value must be greater than 0");
            }
            Content = content;
            DiscountValue = discountValue;
        }

        public void UpdateActiveDate(DateTime newStartDate,DateTime newExpireDate)
        {
            if (newStartDate < DateTime.Now)
            {
                throw new InvalidDataException("Invalid promotion date");
            }
            if (newExpireDate < newStartDate)
            {
                newExpireDate = newStartDate.AddDays(1);
            }
            StartDate = newStartDate;
            ExpireDate = newExpireDate;
        }
    }
}
