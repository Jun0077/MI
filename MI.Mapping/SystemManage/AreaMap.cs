





using MI.Domain.Entity.SystemManage;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MI.Mapping.SystemManage
{
    public class AreaMap : EntityTypeConfiguration<AreaEntity>
    {
        public AreaMap()
        {
            this.ToTable("Sys_Area");
            this.HasKey(t => t.F_Id);
        }
    }

    public class ConfigApi : EntityTypeConfiguration<ConfigApi>
    {

        /// <summary>
        /// Id
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// 键
        /// </summary>		
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>		
        public string Value { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }

    }

}
