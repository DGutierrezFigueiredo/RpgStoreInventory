using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Domain.Interfaces
{
    public interface IRpgItemStoreRepository
    {
        public List<RpgInventoryItem> GetAllItems();

        public RpgInventoryItem GetItemByIdNumber(string ItemIdNumber);

        public RpgInventoryItem Create(RpgInventoryItem item);

        public RpgInventoryItem Remove(string ItemIdNumber);

        public RpgInventoryItem UpdateSellPrice(string ItemIdNumber, decimal newSellPrice);

        public RpgInventoryItem UpdateBuyPrice(string ItemIdNumber, decimal newBuyPrice);

        public RpgInventoryItem UpdateItemDescription(string ItemIdNumber, string newValue);

        public RpgInventoryItem UpdateItemField(string id, string field, string newValue);

    }
}
