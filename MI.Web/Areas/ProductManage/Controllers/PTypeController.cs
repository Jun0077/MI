using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MI.Application.ProductManage;
using MI.Domain.Entity.ProductManage;
using MI.Code;

namespace MI.Web.Areas.ProductManage.Controllers
{
    public class PTypeController : ControllerBase
    {


        private ProductApp app = new ProductApp();
        //
        // GET: /ProductManage/PType/

        public ActionResult GetTreeJson()
        {
            var data = app.GetProductTypeList();
            var treeList = new List<TreeViewModel>();
            foreach (BI_ProductTypeEntity item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_Id;
                tree.parentId = item.F_ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }

        public ActionResult GetTreeSelectJson()
        {
            var data = app.GetProductTypeList();
            var treeList = new List<TreeSelectModel>();
            foreach (BI_ProductTypeEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

        public ActionResult GetGridTreeJson()
        {
            var data = app.GetProductTypeList();
            var treeList = new List<TreeGridModel>();
            foreach (BI_ProductTypeEntity item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                treeModel.id = item.F_Id;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.F_ParentId;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }

        public ActionResult SubmitType(BI_ProductTypeEntity entity, string keyValue)
        {
            app.SubmitProductType(entity,keyValue);

            return Success("操作成功！");
        }

        public ActionResult GetProductTypeJson(string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
                return Content("null");

            var data = app.GetProductTypeEntity(keyValue);
            return Content(data.ToJson());
        }

        public ActionResult DeleteProductType(string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
                return Error("删除的类型主键不能为空","keyValue is null");

            if (!app.IsHasChaild(keyValue))
                return Error("不能删除还有子项的类型","keyValue:"+keyValue);

            app.DeleteProductType(keyValue);
            return Success("操作成功！");
        }

    }
}
