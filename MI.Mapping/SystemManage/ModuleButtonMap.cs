﻿





using MI.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace MI.Mapping.SystemManage
{
    public class ModuleButtonMap : EntityTypeConfiguration<ModuleButtonEntity>
    {
        public ModuleButtonMap()
        {
            this.ToTable("Sys_ModuleButton");
            this.HasKey(t => t.F_Id);
        }
    }
}
