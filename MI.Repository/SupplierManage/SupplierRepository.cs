using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MI.Domain.Entity.SupplierManage;
using MI.Domain.IRepository.SupplierManage;
using MI.Data;
using MI.Code;

namespace MI.Repository.SupplierManage
{
    public class SupplierRepository : RepositoryBase<SupplierInfoEntity>, ISupplierRepository
    {
       
    }
}
