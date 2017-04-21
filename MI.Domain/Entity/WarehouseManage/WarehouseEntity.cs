using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI.Domain.Entity.WarehouseManage
{
    public class WarehouseEntity : IEntity<WarehouseEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {

        public string F_Id { get; set; }

        public string F_ParentId { get; set; }

        /// <summary>
        /// 组织主键
        /// </summary>
        public string F_OrganizeId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string F_EnCode { get; set; }

        public string F_FullName { get; set; }

        /// <summary>
        /// 仓库类型1:实体0:虚拟仓库
        /// </summary>
        public int F_Type { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string F_Address { get; set; }

        /// <summary>
        /// 货架号
        /// </summary>

        public string F_ShelfSize { get; set; }

        /// <summary>
        /// 货架存储位数
        /// </summary>
        public int? F_ShelfNumber { get; set; }

        /// <summary>
        /// 货架存储层数
        /// </summary>
        public int? F_ShelfLayer { get; set; }

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
