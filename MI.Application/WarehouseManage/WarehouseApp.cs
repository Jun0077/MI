using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MI.Domain.Entity.WarehouseManage;
using MI.Domain.IRepository.WarehouseManage;
using MI.Repository.WarehouseManage;
using MI.Code;

namespace MI.Application.WarehouseManage
{
    public class WarehouseApp
    {
        private  IWarehouseRepository repository = new WarehouseRepository();
        private IStorageLocationReository storagelocationApp = new StorageLocationReository();
        /// <summary>
        /// 提交仓库信息
        /// </summary>
        /// <param name="entity"></param>
        public void SubmitForm(WarehouseEntity warehouseEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                warehouseEntity.Modify(keyValue);
                repository.Update(warehouseEntity);
            }
            else
            {
                warehouseEntity.Create();
                repository.Insert(warehouseEntity);
            }
        }


        public List<WarehouseEntity> GetList(string keyword)
        {
            var expression = ExtLinq.True<WarehouseEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
            }
            return repository.IQueryable(expression).OrderByDescending(o => o.F_CreatorTime).ToList();
           
        }

        public List<WarehouseEntity> GetList()
        {
            return repository.IQueryable().OrderByDescending(o => o.F_CreatorTime).ToList();
        }



        public WarehouseEntity GetForm(string keyValue)
        {
            return repository.FindEntity(keyValue);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            if (repository.IQueryable().Count(t => t.F_ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else if (!storagelocationApp.IsUsingForStorageLocation(keyValue))
            {
                throw new Exception("删除失败！操作的对象已经有库位在使用中。");
            }
            else
            {
                repository.Delete(t => t.F_Id == keyValue);
            }
        }

        public string GetStorageLocationPreEncode(string warehouseId)
        {
            if (string.IsNullOrWhiteSpace(warehouseId))
                return null;
            return repository.GetStorageLocationPreEncode(warehouseId);
        }

    }
}
