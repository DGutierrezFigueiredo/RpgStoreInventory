using MongoDB.Driver;
using StoreInventoryManagement.Domain;
using StoreInventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreInventoryManagement.Infrastructure
{
    public class RpgItemStoreRepository : IRpgItemStoreRepository
    {
        private readonly IMongoCollection<RpgInventoryItem> _rpgInventoryItemCollection;
        public RpgItemStoreRepository(IRpgItemStoreRepositorySettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);

            _rpgInventoryItemCollection = database.GetCollection<RpgInventoryItem>(settings.RpgStoreItemInventoryCollectionName);
        }

        public RpgInventoryItem Create(RpgInventoryItem rpgInventoryItem)
        {
            _rpgInventoryItemCollection.InsertOne(rpgInventoryItem);
            return rpgInventoryItem;
        }

        public List<RpgInventoryItem> GetAllItems() => 
            _rpgInventoryItemCollection.Find(item => true).SortBy(item => item.ItemName).ToList();
                    

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
