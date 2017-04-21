using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MI.Domain.Entity.WarehouseManage;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MI.Mapping.WarehouseManage
{
  public  class WarehouseMap: EntityTypeConfiguration<WarehouseEntity>
    {

        public WarehouseMap()
        {
            this.ToTable("WH_Warehouse");
            this.HasKey(o => o.F_Id);
        }

       
     


    }
}
