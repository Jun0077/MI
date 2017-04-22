using System.Data.Entity.ModelConfiguration;
using MI.Domain.Entity.WarehouseManage;

namespace MI.Mapping.WarehouseManage
{
  public  class StorageLocationMap:EntityTypeConfiguration<StorageLocationEntity>
    {

        public StorageLocationMap()
        {
            this.ToTable("dbo.WH_StorageLocation");
            this.HasKey(_ => _.F_Id);
        }

    }
}
