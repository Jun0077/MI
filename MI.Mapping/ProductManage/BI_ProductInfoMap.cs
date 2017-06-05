using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MI.Domain.Entity.ProductManage;

namespace MI.Mapping.ProductManage
{
   public class BI_ProductInfoMap:EntityTypeConfiguration<BI_ProductInfoEntity>
    {
        public BI_ProductInfoMap()
        {
            this.ToTable("BI_ProductInfo");
            this.HasKey(_ => _.F_Id);
        }
    }
}
