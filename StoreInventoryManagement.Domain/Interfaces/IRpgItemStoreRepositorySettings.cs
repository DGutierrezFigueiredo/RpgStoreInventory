using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManagement.Domain.Interfaces
{
    public interface IRpgItemStoreRepositorySettings
    {
        public string RpgStoreItemInventoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }

    }
}
