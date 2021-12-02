using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Domain.Interfaces
{
    public interface IRpgInventoryItem
    {
        //public Guid GetIdGuidNumber();
        
        
        public string GetItemName();
        public void SetItemName(string value);
        public string GetItemDescription();
        public void SetItemDescription(string value);
        public bool GetIsKeyItem();
        public void SetIsKeyItem(bool value);
        public decimal GetItemSellPrice();
        public void SetItemSellPrice(decimal value);
        public decimal GetItemBuyPrice();
        public void SetItemBuyPrice(decimal value);
        public string GetItemRarity();
        public void SetItemRarity(string value);
        public void SetItemCreationDateOnDB(DateTime timeNow);
        public DateTime GetItemCreationDateOnDB();

    }
}
