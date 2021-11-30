using StoreInventoryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Infrastructure
{
    public class RpgItemStoreRepositorySettings : IRpgItemStoreRepositorySettings
    {
        public string RpgStoreItemInventoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
