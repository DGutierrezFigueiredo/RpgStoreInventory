using StoreInventoryManagement.Domain.Interfaces;
using StoreInventoryManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Domain.ModelMappers
{
    public class RpgInventoryItemJsonMapper : IRpgInventoryItemJsonMapper
    {
        //Receives a Json file with item's properties and makes the equivalence (json-object's fields) to generate item's object

        
        public RpgInventoryItem RpgInventoryItemMapper(RpgInventoryItemJson rpgInventoryItemJson)
        {
            RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
            rpgInventoryItem.SetItemName(rpgInventoryItemJson.InventoryItemName);
            rpgInventoryItem.SetItemDescription(rpgInventoryItemJson.ItemDescription);
            rpgInventoryItem.SetIsKeyItem(rpgInventoryItemJson.IsKeyItem);
            rpgInventoryItem.SetItemSellPrice(rpgInventoryItemJson.ItemSellPrice);
            rpgInventoryItem.SetItemBuyPrice(rpgInventoryItemJson.ItemBuyPrice);
            rpgInventoryItem.SetItemRarity(rpgInventoryItemJson.ItemRarity);
            rpgInventoryItem.SetItemCreationDateOnDB(DateTime.Now);

            return rpgInventoryItem;
        }
    }
}
