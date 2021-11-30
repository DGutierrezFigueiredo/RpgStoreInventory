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
        private readonly IRpgItemStoreRepository _rpgItemStoreRepository;
        public RpgItemStoreService(IRpgItemStoreRepository rpgItemStoreRepository)
        {
            _rpgItemStoreRepository = rpgItemStoreRepository;
        }

        public RpgInventoryItem CreateItem(RpgInventoryItem rpgInventoryItem)
        {
            RpgInventoryItem newItem = new RpgInventoryItem();
            newItem = _rpgItemStoreRepository.Create(rpgInventoryItem);
            return newItem;
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
