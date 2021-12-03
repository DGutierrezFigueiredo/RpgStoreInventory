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
        private readonly IRpgItemStorePriceCalculator _rpgItemStorePriceCalculator;
        public RpgItemStoreRepository(IRpgItemStoreRepositorySettings settings, IRpgItemStorePriceCalculator rpgItemStorePriceCalculator)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);

            _rpgInventoryItemCollection = database.GetCollection<RpgInventoryItem>(settings.RpgStoreItemInventoryCollectionName);
            _rpgItemStorePriceCalculator = rpgItemStorePriceCalculator;
        }

        public RpgInventoryItem Create(RpgInventoryItem rpgInventoryItem)
        {
            _rpgInventoryItemCollection.InsertOne(rpgInventoryItem);
            return rpgInventoryItem;
        }

        public List<RpgInventoryItem> GetAllItems() =>
            _rpgInventoryItemCollection.Find(item => true).SortBy(item => item.ItemName).ToList();


        public RpgInventoryItem GetItemByIdNumber(string itemIdNumber)
        {
            RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
            rpgInventoryItem = _rpgInventoryItemCollection.Find<RpgInventoryItem>(item => item.IdGuidNumber == Guid.Parse(itemIdNumber)).FirstOrDefault();
            return rpgInventoryItem;
        }

        public RpgInventoryItem Remove(string ItemIdNumber)
        {
            RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
            rpgInventoryItem = _rpgInventoryItemCollection.FindOneAndDelete(item => item.IdGuidNumber == Guid.Parse(ItemIdNumber));
            return rpgInventoryItem;
        }


        public RpgInventoryItem UpdateItemDescription(string itemIdNumber, string newValue)
        {
            RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
            rpgInventoryItem = GetItemByIdNumber(itemIdNumber);
            rpgInventoryItem.ItemDescription = newValue;
            _rpgInventoryItemCollection.ReplaceOne(item => item.IdGuidNumber == Guid.Parse(itemIdNumber), rpgInventoryItem);
            rpgInventoryItem = GetItemByIdNumber(itemIdNumber);
            return rpgInventoryItem;
        }

        public RpgInventoryItem UpdateItemField(string id, string field, string newValue)
        {

            RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
            rpgInventoryItem = GetItemByIdNumber(id);

            switch (field.ToUpper())
            {

                case "NAME":
                    {
                        rpgInventoryItem.ItemName = newValue;
                        _rpgInventoryItemCollection.ReplaceOne(item => item.IdGuidNumber == Guid.Parse(id), rpgInventoryItem);
                        rpgInventoryItem = GetItemByIdNumber(id);
                        return rpgInventoryItem;
                    }

                case "DESCRIPTION":
                    {
                        rpgInventoryItem.ItemDescription = newValue;
                        _rpgInventoryItemCollection.ReplaceOne(item => item.IdGuidNumber == Guid.Parse(id), rpgInventoryItem);
                        rpgInventoryItem = GetItemByIdNumber(id);
                        return rpgInventoryItem;
                    }

                case "BUYPRICE":
                    {
                        rpgInventoryItem.ItemBuyPrice = decimal.Parse(newValue);
                        rpgInventoryItem.ItemSellPrice = _rpgItemStorePriceCalculator.PriceCalculator(decimal.Parse(newValue));
                        _rpgInventoryItemCollection.ReplaceOne(item => item.IdGuidNumber == Guid.Parse(id), rpgInventoryItem);
                        rpgInventoryItem = GetItemByIdNumber(id);
                        return rpgInventoryItem;
                    }

                case "RARITY":
                    {
                        rpgInventoryItem.ItemRarity = newValue;
                        _rpgInventoryItemCollection.ReplaceOne(item => item.IdGuidNumber == Guid.Parse(id), rpgInventoryItem);
                        rpgInventoryItem = GetItemByIdNumber(id);
                        return rpgInventoryItem;
                    }

                case "ISKEYITEM":
                    {
                        rpgInventoryItem.IsKeyItem = bool.Parse(newValue);
                        _rpgInventoryItemCollection.ReplaceOne(item => item.IdGuidNumber == Guid.Parse(id), rpgInventoryItem);
                        rpgInventoryItem = GetItemByIdNumber(id);
                        return rpgInventoryItem;
                    }

                default:
                    return rpgInventoryItem;
                    
            }
            
        }

        public RpgInventoryItem UpdateBuyPrice(string ItemIdNumber, decimal newBuyPrice)
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem UpdateSellPrice(string ItemIdNumber, decimal newSellPrice)
        {
            throw new NotImplementedException();
        }
    }
}
