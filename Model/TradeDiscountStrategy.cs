using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class TradeDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyExtraDiscountsTo(decimal originalSalePrice)
        {
            decimal price = originalSalePrice;
            price = price*0.95M;
            return price;
        }
    }
}