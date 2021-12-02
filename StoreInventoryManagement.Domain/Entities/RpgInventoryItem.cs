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
    public class RpgInventoryItem //: IRpgInventoryItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid IdGuidNumber { get; set; }
               
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public bool IsKeyItem { get; set; }

        public decimal ItemSellPrice { get; set; }

        public decimal ItemBuyPrice { get; set; }
        public string ItemRarity { get; set; }
        public DateTime ItemCreationDateOnDb { get; set; }

        public RpgInventoryItem()
        {

        }

        public RpgInventoryItem(string id, Guid idGuidNumber, string itemName, string itemDescription, bool isKeyItem, decimal itemSellPrice,
                                                   decimal itemBuyPrice, string itemRarity, DateTime itemCreationDateOnDb)//DateTime here on the constructor??
        {
            Id = id;
            IdGuidNumber = idGuidNumber;
            ItemName = itemName;
            ItemDescription = itemDescription;
            IsKeyItem = isKeyItem;
            ItemSellPrice = itemSellPrice;
            ItemBuyPrice = itemBuyPrice;
            ItemRarity = itemRarity;
            ItemCreationDateOnDb = itemCreationDateOnDb;

        }


    }
}
