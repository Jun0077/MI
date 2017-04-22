using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MI.Code;
using MI.Domain.Entity.WarehouseManage;
using MI.Domain.IRepository.WarehouseManage;
using MI.Data;

namespace MI.Repository.WarehouseManage
{
    public class StorageLocationReository : RepositoryBase<StorageLocationEntity>, IStorageLocationReository
    {
    
        public void ClearStorageLocation(IEnumerable<StorageLocationEntity> entities)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                foreach (var entity in entities)
                    db.Delete<StorageLocationEntity>(entity);
                db.Commit();
            }
           
        }

        public void SubmitBatch(IEnumerable<StorageLocationEntity> entities)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                foreach (var entity in entities)
                    db.Insert<StorageLocationEntity>(entity);
                db.Commit();
            }
        }


        public bool IsUsingForStorageLocation(string warehouseId)
        {
            var expression = ExtLinq.True<StorageLocationEntity>();
            expression.And(_ => _.F_Warehouse == warehouseId);
            var list = IQueryable(expression).ToList();
            if (list?.Where(_ => _.F_Status == 1)?.Count() > 0)
                return false;
            else
                return true;
        }
    }
}
