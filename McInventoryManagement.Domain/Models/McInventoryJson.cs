using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace McInventoryManagement.Domain.Models
{
    public class McInventoryJson : IMcInventoryJson
    {
        [JsonPropertyName("Item Id")]
        public string ItemIdJson { get; set; }
        [JsonPropertyName("Item Name")]
        public string ItemNameJson { get; set; }
        [JsonPropertyName("Item Description")]
        public string ItemDescription { get; set; }
        [JsonPropertyName("Item Rarity")]
        public string ItemRarity { get; set; }
        [JsonPropertyName("Item Qauntity")]
        public static int ItemQuantity { get; private set; }
        [JsonPropertyName("Available Funds")]
        public double McFunds { get; private set; }
    }
}
