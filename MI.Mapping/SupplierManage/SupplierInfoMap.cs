using MI.Domain.Entity.SupplierManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI.Mapping.SupplierManage
{
  public  class SupplierInfoMap: EntityTypeConfiguration<SupplierInfoEntity>
    {

        public SupplierInfoMap()
        {
            this.ToTable("dbo.BI_SupplierInfo");
            this.HasKey(_ => _.F_Id);
        }

    }
}
