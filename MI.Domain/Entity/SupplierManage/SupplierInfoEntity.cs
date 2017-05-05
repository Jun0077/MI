using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI.Domain.Entity.SupplierManage
{
    public class SupplierInfoEntity : IEntity<SupplierInfoEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string F_Id { get; set; }

        public string F_FullName { get; set; }

        public string F_NickName { get; set; }

        public string F_OrganizeId { get; set; }

        public int? F_SupplierType { get; set; }

        public string F_AreaIdProvince { get; set; }

        public string F_AreaIdCity { get; set; }

        public string F_Linkman { get; set; }

        public string F_ContactNumber { get; set; }

        public string F_Email { get; set; }

        public string F_Fax { get; set; }

        public string F_Address { get; set; }

        public bool? F_AllowEdit { get; set; }

        public bool? F_AllowDelete { get; set; }

        public int? F_SortCode { get; set; }


        public bool? F_EnabledMark { get; set; }

        public string F_Description { get; set; }

        public DateTime? F_CreatorTime
        {
            get; set;
        }

        public string F_CreatorUserId
        {
            get; set;
        }

        public bool? F_DeleteMark
        {
            get; set;
        }

        public DateTime? F_DeleteTime
        {
            get; set;
        }

        public string F_DeleteUserId
        {
            get; set;
        }

        public DateTime? F_LastModifyTime
        {
            get; set;
        }

        public string F_LastModifyUserId
        {
            get; set;
        }
    }
}
