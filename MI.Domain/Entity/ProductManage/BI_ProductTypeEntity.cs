﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI.Domain.Entity.ProductManage
{
   public class BI_ProductTypeEntity: IEntity<BI_ProductTypeEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        /// <summary>
        /// F_Id
        /// </summary>		
        public string F_Id { get; set; }

        /// <summary>
        /// F_ParentId
        /// </summary>		
        public string F_ParentId { get; set; }

        /// <summary>
        /// 组织主键
        /// </summary>		
        public string F_OrganizeId { get; set; }

        /// <summary>
        /// F_FullName
        /// </summary>		
        public string F_FullName { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>		
        public bool? F_AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>		
        public bool? F_AllowDelete { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>		
        public int? F_SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>		
        public bool? F_DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>		
        public bool? F_EnabledMark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>		
        public string F_Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime? F_CreatorTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>		
        public string F_CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>		
        public DateTime? F_LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>		
        public string F_LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>		
        public DateTime? F_DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>		
        public string F_DeleteUserId { get; set; }
    }
}
