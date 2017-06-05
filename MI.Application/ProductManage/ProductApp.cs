using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MI.Domain.IRepository.ProductManage;
using MI.Domain.Entity.ProductManage;
using MI.Repository.ProductManage;
using MI.Code;
using MI.Data;
using System.Linq.Expressions;


namespace MI.Application.ProductManage
{
   public class ProductApp
    {
        private  IProductTypeRepository typeApp = new ProductTypeRepository();
        private  IProductInfoRepository infoApp = new ProductInfoRepository();


        public ProductApp()
        {

        }
        #region 商品类型

        public void SubmitProductType(BI_ProductTypeEntity entity,string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
            {
                entity.F_OrganizeId = OperatorProvider.Provider.GetCurrent().CompanyId;
                entity.Create();
                typeApp.Insert(entity);
            }
            else
            {
                entity.Modify(keyValue);
                typeApp.Update(entity);
            }
        }

        public IEnumerable<BI_ProductTypeEntity> GetProductTypeList()
        {
            var ext = ExtLinq.True<BI_ProductTypeEntity>();
            ext.And(_ => _.F_OrganizeId == OperatorProvider.Provider.GetCurrent().CompanyId);
            return typeApp.IQueryable(ext).ToList<BI_ProductTypeEntity>();
        }

        public BI_ProductTypeEntity GetProductTypeEntity(string keyValue)
        {
            return typeApp.FindEntity(keyValue);
        }

        public void DeleteProductType(string keyValue)
        {
            var entity = typeApp.FindEntity(keyValue);
            typeApp.Delete(entity);
        }

        public bool IsHasChaild(string parentId)
        {
            var data = typeApp.IQueryable()?.ToList()?.Where(_=>_.F_ParentId.ToLower().Trim()==parentId.ToLower().Trim());
            if (data == null || data?.Count() == 0)
                return true;
            else
                return false;
        }
        #endregion


        public void SubmitForm(BI_ProductInfoEntity entity, string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
            {
                entity.Create();
                entity.F_EnabledMark = true;
                infoApp.Insert(entity);
            }
            else
            {
                entity.Modify(keyValue);
                infoApp.Update(entity);
            }
        }

        public BI_ProductInfoEntity GetForm(string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
                return null;
            return infoApp.FindEntity(keyValue);
        }

        public void DeleteForm(string keyValue)
        {
            var entity = infoApp.FindEntity(keyValue);
            entity.Modify(keyValue);
            entity.F_DeleteTime = DateTime.Now;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
                entity.F_DeleteUserId = LoginInfo.UserId;
            entity.F_EnabledMark = false;
            infoApp.Update(entity);
        }

        public List<BI_ProductInfoEntity> GetGridList(Pagination pagination, string productId, string keyword)
        {
            var ext = ExtLinq.True<BI_ProductInfoEntity>();

            Expression<Func<BI_ProductInfoEntity, bool>> expression = _ => _.F_EnabledMark == true && _.F_ProductTypeId == productId;
            if (!string.IsNullOrWhiteSpace(keyword))
                expression = _ => _.F_EnabledMark == true && _.F_ProductTypeId == productId && (_.F_FullName.ToString().Contains(keyword) || _.F_NickName.ToString().Contains(keyword));
            return infoApp.FindList(expression, pagination);
        }

    }
}
