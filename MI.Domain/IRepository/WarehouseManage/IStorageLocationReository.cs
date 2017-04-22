using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MI.Domain.Entity.WarehouseManage;
using MI.Data;

namespace MI.Domain.IRepository.WarehouseManage
{
   public interface IStorageLocationReository: IRepositoryBase<StorageLocationEntity>
    {
        /// <summary>
        /// 创建库位
        /// </summary>
        /// <param name="warehouseId"></param>
        void SubmitBatch(IEnumerable<StorageLocationEntity> entities);

        void ClearStorageLocation(IEnumerable<StorageLocationEntity> entities);


        /// <summary>
        /// 判断货架是否空闲
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        bool IsUsingForStorageLocation(string warehouseId);

    }
}
