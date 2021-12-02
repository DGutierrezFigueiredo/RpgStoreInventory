using StoreInventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Service
{
    public class RpgItemStorePriceCalculator : IRpgItemStorePriceCalculator
    {
        public decimal PriceCalculator(decimal buyPrice)
        {
            return buyPrice * (decimal)0.3;
        }
                
    }
}
