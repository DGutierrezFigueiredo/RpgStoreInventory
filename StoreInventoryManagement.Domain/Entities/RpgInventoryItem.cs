using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StoreInventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Domain
{
    //Entities go in Domain
    public class RpgInventoryItem// : IRpgInventoryItem
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]

        //private readonly Guid _idGuidNumber;

        //public Guid GetIdGuidNumber()
        //{
        //    return _idGuidNumber;
        //}

        private string _itemName;

        public string GetItemName()
        {
            return _itemName;
        }

        public void SetItemName(string value)
        {
            _itemName = value;
        }

        private string _itemDescription;

        public string GetItemDescription()
        {
            return _itemDescription;
        }

        public void SetItemDescription(string value)
        {
            _itemDescription = value;
        }

        private bool _isKeyItem;

        public bool GetIsKeyItem()
        {
            return _isKeyItem;
        }

        public void SetIsKeyItem(bool value)
        {
            _isKeyItem = value;
        }

        private decimal _itemSellPrice;

        public decimal GetItemSellPrice()
        {
            return _itemSellPrice;
        }

        public void SetItemSellPrice(decimal value)
        {
            _itemSellPrice = value;
        }

        private decimal _itemBuyPrice;

        public decimal GetItemBuyPrice()
        {
            return _itemBuyPrice;
        }

        public void SetItemBuyPrice(decimal value)
        {
            _itemBuyPrice = value;
        }

        private string _itemRarity;

        public string GetItemRarity()
        {
            return _itemRarity;
        }

        public void SetItemRarity(string value)
        {
            _itemRarity = value;
        }

        private DateTime _itemCreationDateOnDB;

        public void SetItemCreationDateOnDB(DateTime timeNow)
        {
            _itemCreationDateOnDB = DateTime.Now;
        }

        public DateTime GetItemCreationDateOnDB()
        {
            return _itemCreationDateOnDB;
        }

        public RpgInventoryItem()//antes era internal
        {

        }

        
        public RpgInventoryItem(string itemName, string itemDescription, bool isKeyItem, decimal itemSellPrice,
                                                   decimal itemBuyPrice, string itemRarity, DateTime itemCriationDateOnDB)//DateTime here on the constructor??
        {
            //_idGuidNumber = idGuidNumber;
            _itemName = itemName;
            _itemDescription = itemDescription;
            _isKeyItem = isKeyItem;
            _itemSellPrice = itemSellPrice;
            _itemBuyPrice = itemBuyPrice;
            _itemRarity = itemRarity;
            _itemCreationDateOnDB = itemCriationDateOnDB;

        }

        
    }
}
