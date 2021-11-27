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

        public RpgInventoryItem GetItemByIdNumber(int ItemIdNumber);

        public RpgInventoryItem Create(RpgInventoryItem item);

        public RpgInventoryItem Remove(int ItemIdNumber);

        public RpgInventoryItem UpdateSellPrice(int ItemIdNumber, decimal newSellPrice);

        public RpgInventoryItem UpdateBuyPrice(int ItemIdNumber, decimal newBuyPrice);

    }
}
