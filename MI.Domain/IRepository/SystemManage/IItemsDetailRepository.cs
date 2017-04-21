





using MI.Data;
using MI.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace MI.Domain.IRepository.SystemManage
{
    public interface IItemsDetailRepository : IRepositoryBase<ItemsDetailEntity>
    {
        List<ItemsDetailEntity> GetItemList(string enCode);
    }
}
