using StoreInventoryManagement.Domain;
using StoreInventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Service
{
    public class RpgItemStoreService : IRpgItemStoreService
    {
        public RpgInventoryItem CreateItem(RpgInventoryItem rpgInventoryItemJson)
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem DeleteItem(int itemIdNumber)
        {
            throw new NotImplementedException();
        }

        public List<RpgInventoryItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem GetItemByIdNumber(int itemIdNumber)
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem UpdateBuyPrice(int itemIdNumber, decimal newBuyPrice)
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem UpdateSellPrice(int itemIdNumber, decimal newSellPrice)
        {
            throw new NotImplementedException();
        }
    }
}
