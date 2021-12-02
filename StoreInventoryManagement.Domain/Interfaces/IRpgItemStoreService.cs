using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Domain.Interfaces
{
    public interface IRpgItemStoreService
    {
        public RpgInventoryItem CreateItem(RpgInventoryItem rpgInventoryItem);

        public RpgInventoryItem DeleteItem(string itemIdNumber);

        public List<RpgInventoryItem> GetAllItems();

        public RpgInventoryItem GetItemByIdNumber(string itemIdNumber);

        public RpgInventoryItem UpdateSellPrice(string itemIdNumber, decimal newSellPrice);

        public RpgInventoryItem UpdateBuyPrice(string itemIdNumber, decimal newBuyPrice);

    }
}
