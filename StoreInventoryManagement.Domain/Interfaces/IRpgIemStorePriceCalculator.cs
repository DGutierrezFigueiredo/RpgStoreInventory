﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Domain.Interfaces
{
    public interface IRpgItemStorePriceCalculator
    {
        public decimal PriceCalculator(decimal buyPrice);
    }
}
