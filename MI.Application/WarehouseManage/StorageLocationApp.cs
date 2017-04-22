using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MI.Domain.IRepository.WarehouseManage;
using MI.Repository.WarehouseManage;
using MI.Domain.Entity.WarehouseManage;
using MI.Code;

namespace MI.Application.WarehouseManage
{
   public class StorageLocationApp
    {
        private IStorageLocationReository repository = new StorageLocationReository();
        private IWarehouseRepository warehouseApp = new WarehouseRepository();

        public IEnumerable<StorageLocationEntity> GetList(string warehouseId)
        {
            var exp =  ExtLinq.True<StorageLocationEntity>();
            exp.And(_ => _.F_Warehouse == warehouseId);
            return repository.IQueryable(exp).OrderBy(_ => _.F_LayerNumber).OrderBy(_ => _.F_SortCode);
        }

        public void SubmitBatch(string warehouseId)
        {
            if (!repository.IsUsingForStorageLocation(warehouseId))
                throw new Exception("货架中有库位正在使用中，不能创建库位列表");

            if(GetList(warehouseId)?.Count()>0)
                throw new Exception("库位已经存在，不能重新创建！");

            List<StorageLocationEntity> list = new List<StorageLocationEntity>();

            var shelftEntity = warehouseApp.FindEntity(warehouseId);
            var preEnCode = warehouseApp.GetStorageLocationPreEncode(warehouseId);

            for (int i = 1; i <= shelftEntity.F_ShelfLayer; i++)
            {
                for (int n = 1; n <= shelftEntity.F_ShelfNumber; n++)
                {
                    StorageLocationEntity entity = new StorageLocationEntity();
                    entity.Create();
                    entity.F_Status = 0;
                    entity.F_EnabledMark = true;
                    entity.F_EnCode = preEnCode + i.ToString("00") + n.ToString("00");
                    entity.F_LayerNumber = i;
                    entity.F_SortCode = n;
                    entity.F_LocationType = 1;//拣货 
                    entity.F_Warehouse = warehouseId;
                    list.Add(entity);
                }
            }
            repository.SubmitBatch(list);
        }

        public void ClearBatch(string warehouseId)
        {
            if (!IsUsingForStorageLocation(warehouseId))
                throw new Exception("货架中有库位正在使用中，不能创建库位列表");

            var list = GetList(warehouseId);
            if (list?.Count() > 0)
                repository.ClearStorageLocation(list);

        }

        public bool IsUsingForStorageLocation(string warehouseId)
        {
            if (string.IsNullOrWhiteSpace(warehouseId))
                return false;
            return repository.IsUsingForStorageLocation(warehouseId);
        }

        public StorageLocationEntity GetForm(string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
                return null;
            return repository.FindEntity(keyValue);
        }

        public void SubmitForm(StorageLocationEntity entity,string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
                throw new Exception("库存F_Id不能为空");
            entity.Modify(keyValue);
            repository.Update(entity);
        }

    }
}
