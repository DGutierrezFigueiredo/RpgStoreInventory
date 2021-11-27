using StoreInventoryManagement.Domain;
using StoreInventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreInventoryManagement.Infrastructure
{
    class RpgItemStoreRepository : IRpgItemStoreRepository
    {
                
        public RpgInventoryItem Create(RpgInventoryItem item)
        {
            throw new NotImplementedException();
        }

        public List<RpgInventoryItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem GetItemByIdNumber(int ItemIdNumber)
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem Remove(int ItemIdNumber)
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem UpdateBuyPrice(int ItemIdNumber, decimal newBuyPrice)
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem UpdateSellPrice(int ItemIdNumber, decimal newSellPrice)
        {
            throw new NotImplementedException();
        }
    }
}
