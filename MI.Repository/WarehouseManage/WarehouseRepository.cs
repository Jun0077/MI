using MI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MI.Domain.Entity.WarehouseManage;
using MI.Domain.IRepository.WarehouseManage;
using MI.Code;

namespace MI.Repository.WarehouseManage
{
   public class WarehouseRepository: RepositoryBase<WarehouseEntity>,IWarehouseRepository
    {
        public string GetStorageLocationPreEncode( string warehouseId)
        {
            string enCode = null;
            if (string.IsNullOrWhiteSpace(warehouseId) || warehouseId == "0")
                return enCode;
            var entity = FindEntity(warehouseId);
            enCode = entity?.F_EnCode;

             return GetStorageLocationPreEncode(entity.F_ParentId) + enCode;
          
        }

        
    }
}
