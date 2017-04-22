using MI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MI.Domain.Entity.WarehouseManage;

namespace MI.Domain.IRepository.WarehouseManage
{
  public  interface IWarehouseRepository: IRepositoryBase<WarehouseEntity>
    {
        /// <summary>
        /// 获取库位前缀编号
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        string GetStorageLocationPreEncode(string warehouseId);

        
    }
}
