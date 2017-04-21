﻿





using MI.Code;
using MI.Domain.Entity.SystemManage;
using MI.Domain.IRepository.SystemManage;
using MI.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MI.Application.SystemManage
{
    public class ModuleApp
    {
        private IModuleRepository service = new ModuleRepository();

        public List<ModuleEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.F_SortCode).ToList();
        }
        public ModuleEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.F_ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.Delete(t => t.F_Id == keyValue);
            }
        }
        public void SubmitForm(ModuleEntity moduleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleEntity.Modify(keyValue);
                service.Update(moduleEntity);
            }
            else
            {
                moduleEntity.Create();
                service.Insert(moduleEntity);
            }
        }
    }
}
