using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MI.Domain.Entity.ProductManage;
using MI.Domain.IRepository.ProductManage;
using MI.Code;
using MI.Data;

namespace MI.Repository.ProductManage
{
   public class ProductTypeRepository: RepositoryBase<BI_ProductTypeEntity>, IProductTypeRepository
    {

    }
}
