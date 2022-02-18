using StoreInventoryManagement.Domain.Interfaces;
using StoreInventoryManagement.Domain.Models;
using StoreInventoryManagement.Service;
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
        
        private readonly IRpgItemStorePriceCalculator _rpgItemStorePriceCalculator;

        public RpgInventoryItemJsonMapper(IRpgItemStorePriceCalculator rpgItemStorePriceCalculator)
        {
            _rpgItemStorePriceCalculator = rpgItemStorePriceCalculator;
        }



        public RpgInventoryItem RpgInventoryItemMapper(RpgInventoryItemJson rpgInventoryItemJson)
        {

            RpgInventoryItem rpgInventoryItem = new RpgInventoryItem();
            rpgInventoryItem.IdGuidNumber = Guid.NewGuid();
            rpgInventoryItem.ItemName = rpgInventoryItemJson.InventoryItemName;
            rpgInventoryItem.ItemDescription = rpgInventoryItemJson.ItemDescription;
            rpgInventoryItem.IsKeyItem = rpgInventoryItemJson.IsKeyItem;
            rpgInventoryItem.ItemSellPrice = _rpgItemStorePriceCalculator.PriceCalculator(rpgInventoryItemJson.ItemBuyPrice);//rpgInventoryItemJson.ItemSellPrice;
            rpgInventoryItem.ItemBuyPrice = rpgInventoryItemJson.ItemBuyPrice;
            rpgInventoryItem.ItemRarity = rpgInventoryItemJson.ItemRarity;
            rpgInventoryItem.ItemCreationDateOnDb = DateTime.Now;

            return rpgInventoryItem;
        }
    }
}
