using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MI.Domain.Entity.SupplierManage;
using MI.Domain.IRepository.SupplierManage;
using MI.Repository.SupplierManage;
using MI.Code;

namespace MI.Application.SupplierManage
{
  public  class SupplierInfoApp
    {
        private ISupplierRepository repository = new SupplierRepository();

        public void SubmitForm(SupplierInfoEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.F_Id))
            {
                entity.Create();
                repository.Insert(entity);
            }
            else
            {
                entity.Modify(entity.F_Id);
                repository.Update(entity);
            }
        }

        public SupplierInfoEntity GetForm(string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
                return null;
            return repository.FindEntity(keyValue);
        }


        public void DeleteForm(string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
                throw new Exception("供应商的删除ID不能为空");
            var entity = repository.FindEntity(keyValue);
            repository.Delete(entity);
        }

        public List<SupplierInfoEntity> GetList( Pagination pagination, string keyWork)
        {
            if (string.IsNullOrWhiteSpace(keyWork))
            {
                return repository.FindList(pagination);
            }
            else
            {
                var ext = ExtLinq.True<SupplierInfoEntity>();
                ext.And(_ => _.F_FullName.Contains(keyWork));
                return repository.FindList(ext, pagination);
            }
        }

    }
}
