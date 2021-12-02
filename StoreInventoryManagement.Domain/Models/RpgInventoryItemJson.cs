using StoreInventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Domain.Models
{
    public class RpgInventoryItemJson //: IRpgInventoryItemJson
    {
        ///[JsonPropertyName("Id")]
        //public string Id { get; }
        //This is kind of a DTO

        [JsonPropertyName("Item Name")]
        public string InventoryItemName { get; set; }

        [JsonPropertyName("Item Description")]
        public string ItemDescription { get; set; }

        [JsonPropertyName("Is Key Item")]
        public bool IsKeyItem { get; set; }

        //[JsonPropertyName("Item Sell Price")]
        //public decimal  ItemSellPrice { get; set; }

        [JsonPropertyName("Item Buy Price")]
        public decimal ItemBuyPrice { get; set; }

        [JsonPropertyName("Item Rarity")]
        public string ItemRarity { get; set; }

        //[JsonPropertyName("Creation Date On DB 'dd/mm/yy'")]
        //public DateTime ItemCreationDate { get; set; }




        public RpgInventoryItemJson()
        {

        }

        public RpgInventoryItemJson(string inventoryItemName, string itemDescription, bool isKeyItem, decimal itemBuyPrice, string itemRarity)
        {
            InventoryItemName = inventoryItemName;
            ItemDescription = itemDescription;
            IsKeyItem = isKeyItem;
            //ItemSellPrice = itemSellPrice;
            ItemBuyPrice = itemBuyPrice;
            ItemRarity = itemRarity;
            //ItemCreationDate = itemCreationDate;
        }
    }
}
