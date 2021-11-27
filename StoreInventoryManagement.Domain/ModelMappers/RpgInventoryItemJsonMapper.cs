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
    class RpgInventoryItemJsonMapper : IRpgInventoryItemJsonMapper
    {
        //Receives a Json file with item's properties and makes the equivalence (json-object's fields) to generate item's object

        private readonly IRpgInventoryItem _rpgInventoryItem;

        public RpgInventoryItemJsonMapper(IRpgInventoryItem rpgInventoryItem)
        {
            _rpgInventoryItem = rpgInventoryItem;
        }
        public RpgInventoryItem RpgInventoryItemMapper(RpgInventoryItem rpgInventoryItem, RpgInventoryItemJson rpgInventoryItemJson)
        {

            _rpgInventoryItem.SetItemName(rpgInventoryItemJson.InventoryItemName);
            _rpgInventoryItem.SetItemDescription(rpgInventoryItemJson.ItemDescription);
            _rpgInventoryItem.SetIsKeyItem(rpgInventoryItemJson.IsKeyItem);
            _rpgInventoryItem.SetItemSellPrice(rpgInventoryItemJson.ItemSellPrice);
            _rpgInventoryItem.SetItemBuyPrice(rpgInventoryItemJson.ItemBuyPrice);
            _rpgInventoryItem.SetItemRarity(rpgInventoryItemJson.ItemRarity);
            

            return rpgInventoryItem;
        }
    }
}
