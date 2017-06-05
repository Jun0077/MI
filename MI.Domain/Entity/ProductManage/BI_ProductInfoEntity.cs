using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI.Domain.Entity.ProductManage
{
    public class BI_ProductInfoEntity: IEntity<BI_ProductInfoEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        /// <summary>
        /// F_Id
        /// </summary>		
        public string F_Id { get; set; }

        /// <summary>
        /// F_EnCode
        /// </summary>		
        public string F_EnCode { get; set; }

        /// <summary>
        /// F_FullName
        /// </summary>		
        public string F_FullName { get; set; }

        /// <summary>
        /// F_NickName
        /// </summary>		
        public string F_NickName { get; set; }

        /// <summary>
        /// F_ProductTypeId
        /// </summary>		
        public string F_ProductTypeId { get; set; }

        /// <summary>
        /// F_Manufactory
        /// </summary>		
        public string F_Manufactory { get; set; }

        /// <summary>
        /// 盒 袋 台 箱  瓶  （字典中）
        /// </summary>		
        public string F_Unit { get; set; }

        /// <summary>
        /// F_IsTreasure
        /// </summary>		
        public bool? F_IsTreasure { get; set; }

        /// <summary>
        /// F_IsBreakables
        /// </summary>		
        public bool? F_IsBreakables { get; set; }

        /// <summary>
        /// F_IsDangerous
        /// </summary>		
        public bool? F_IsDangerous { get; set; }

        /// <summary>
        /// F_IsPerishableItem
        /// </summary>		
        public bool? F_IsPerishableItem { get; set; }

        /// <summary>
        /// F_IsUnShelfLife
        /// </summary>		
        public bool? F_IsUnShelfLife { get; set; }

        /// <summary>
        /// F_ValidDate
        /// </summary>		
        public int? F_ValidDate { get; set; }

        /// <summary>
        /// F_Bulk
        /// </summary>		
        public decimal? F_Bulk { get; set; }

        /// <summary>
        /// F_Color
        /// </summary>		
        public string F_Color { get; set; }

        /// <summary>
        /// F_Weight
        /// </summary>		
        public decimal? F_Weight { get; set; }

        /// <summary>
        /// 规则形状 不规则形状 特异物体
        /// </summary>		
        public string F_Shape { get; set; }

        /// <summary>
        /// F_MaxStock
        /// </summary>		
        public decimal? F_MaxStock { get; set; }

        /// <summary>
        /// F_MinStock
        /// </summary>		
        public decimal? F_MinStock { get; set; }

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
