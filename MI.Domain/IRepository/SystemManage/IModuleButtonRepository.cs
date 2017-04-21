





using MI.Data;
using MI.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace MI.Domain.IRepository.SystemManage
{
    public interface IModuleButtonRepository : IRepositoryBase<ModuleButtonEntity>
    {
        void SubmitCloneButton(List<ModuleButtonEntity> entitys);
    }
}
