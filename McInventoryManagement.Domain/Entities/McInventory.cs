using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McInventoryManagement.Domain.Entities
{
    public class McInventory
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemRarity { get; set; }
        public static int ItemQuantity { get; private set; }
        public static double McFunds { get; private set; }

        public List<Items> GetItems()
        {
          ////something 
          //return null;
        }

        public List<Items> GetMcItems()
        {
          ////something some
        }
    }
}
