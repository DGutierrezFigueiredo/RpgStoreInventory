using StoreInventoryManagement.Domain.Interfaces;
using StoreInventoryManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Domain.ModelMappers
{
    public interface IRpgInventoryItemJsonMapper
    {
        public RpgInventoryItem RpgInventoryItemMapper(RpgInventoryItem rpgInventoryItem, RpgInventoryItemJson rpgInventoryItemJson);

    }
}
