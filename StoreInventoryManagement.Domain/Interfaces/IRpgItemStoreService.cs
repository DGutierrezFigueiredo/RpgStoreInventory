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

        public RpgInventoryItem DeleteItem(int itemIdNumber);

        public List<RpgInventoryItem> GetAllItems();

        public RpgInventoryItem GetItemByIdNumber(int itemIdNumber);

        public RpgInventoryItem UpdateSellPrice(int itemIdNumber, decimal newSellPrice);

        public RpgInventoryItem UpdateBuyPrice(int itemIdNumber, decimal newBuyPrice);

    }
}
