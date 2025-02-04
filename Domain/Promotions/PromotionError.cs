using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Promotions
{
    internal class PromotionError
    {
        public static readonly Error NegativeDiscountValue = Error.InvalidData("Discount value must be greater than 0");
        public static readonly Error InvalidExpireDate = Error.InvalidData("Expire date invalid");
        public static readonly Error EmptyPromotionContent = Error.InvalidData("Content must not be empty");
    }
}
