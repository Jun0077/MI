using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MI.Domain.Entity.ProductManage;

namespace MI.Mapping.ProductManage
{
   public class BI_ProductTypeMap:EntityTypeConfiguration<BI_ProductTypeEntity>
    {
        public BI_ProductTypeMap()
        {
            this.ToTable("BI_ProductTypeInfo");
            this.HasKey(_ => _.F_Id);
        }
    }
}
