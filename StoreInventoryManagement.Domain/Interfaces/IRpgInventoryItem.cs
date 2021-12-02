using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Domain.Interfaces
{
    public interface IRpgInventoryItem
    {
        public string Id { get; set; }
        public Guid IdGuidNumber { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public bool IsKeyItem { get; set; }
        public decimal ItemSellPrice { get; set; }
        public decimal ItemBuyPrice { get; set; }
        public string ItemRarity { get; set; }
        public DateTime ItemCreationDateOnDb { get; set; }

    }
}
