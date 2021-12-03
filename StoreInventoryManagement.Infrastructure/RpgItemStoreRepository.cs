﻿using MongoDB.Driver;
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

        public RpgInventoryItem UpdateBuyPrice(string ItemIdNumber, decimal newBuyPrice)
        {
            throw new NotImplementedException();
        }

        public RpgInventoryItem UpdateSellPrice(string ItemIdNumber, decimal newSellPrice)
        {
            throw new NotImplementedException();
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
    }
}
