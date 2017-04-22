using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI.Domain.Entity.WarehouseManage
{
    /// <summary>
    /// 库位信息表
    /// </summary>
   public class StorageLocationEntity : IEntity<WarehouseEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string F_Id { get; set; }

        public string F_Warehouse { get; set; }

        public int? F_LocationType { get; set; }


        /// <summary>
        /// 1已占用 0:空闲中
        /// </summary>
        public int F_Status { get; set; }

        /// <summary>
        /// 所属的层数
        /// </summary>
        public int F_LayerNumber { get; set; }


        public string F_EnCode { get; set; }

        public bool? F_AllowEdit { get; set; }

        public bool? F_AllowDelete { get; set; }

        public int? F_SortCode { get; set; }
        public bool? F_DeleteMark { get; set; }
        public bool? F_EnabledMark { get; set; }


        public string F_Description { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_DeleteUserId { get; set; }

    }
}
