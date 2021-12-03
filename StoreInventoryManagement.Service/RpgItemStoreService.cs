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

        public RpgInventoryItem DeleteItem(string itemIdNumber)
        {
            RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
            rpgInventoryItem = _rpgItemStoreRepository.Remove(itemIdNumber);
            return rpgInventoryItem;
        }

        public List<RpgInventoryItem> GetAllItems()
        {
            List<RpgInventoryItem> listOfAllItems = new List<RpgInventoryItem>();
            listOfAllItems = _rpgItemStoreRepository.GetAllItems();
            return listOfAllItems;
        }

        public RpgInventoryItem GetItemByIdNumber(string itemIdNumber)
        {
            RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
            rpgInventoryItem = _rpgItemStoreRepository.GetItemByIdNumber(itemIdNumber);
            return rpgInventoryItem;
        }

        public RpgInventoryItem UpdateBuyPrice(string itemIdNumber, decimal newBuyPrice)
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem UpdateSellPrice(string itemIdNumber, decimal newSellPrice)
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem UpdateItemDescription(string itemIdNumber, string newValue)
        {
            RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
            rpgInventoryItem = _rpgItemStoreRepository.UpdateItemDescription(itemIdNumber, newValue);
            return rpgInventoryItem;
        }
    }
}
