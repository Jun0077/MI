using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MI.Domain.Entity.WarehouseManage;
using MI.Application.WarehouseManage;
using MI.Code;

namespace MI.Web.Areas.WarehouseManage.Controllers
{
    public class WarehouseController : ControllerBase
    {
        //
        // GET: /WarehouseManage/Warehouse/
       private  WarehouseApp warehouseApp = new WarehouseApp();

        #region 仓库列表

        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(WarehouseEntity entity, string keyValue)
        {
           
            try
            {
                warehouseApp.SubmitForm(entity,keyValue);
            }
            catch (Exception em)
            {
                return Error("保存失败",em.Message);
            }
            return Success("保存成功");
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridTreeJson(string keyword)
        {
          
            var data = warehouseApp.GetList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.F_FullName.Contains(keyword));
                data = data.TreeWhere(t => t.F_Type != null);
            }
            var treeList = new List<TreeGridModel>();
            foreach (WarehouseEntity item in data)
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

        public ActionResult GetTreeJson()
        {
            var data = warehouseApp.GetList();
            data = data.TreeWhere(t => t.F_Type != null);
            var treeList = new List<TreeViewModel>();
            foreach (WarehouseEntity item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_EnCode;
                tree.parentId = item.F_ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
           
            var data = warehouseApp.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (WarehouseEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = item.F_ParentId;
                treeModel.data = item;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }
        public ActionResult GetFormJson(string keyValue)
        {
            return Content(warehouseApp.GetForm(keyValue).ToJson());
        }


        public ActionResult DeleteForm(string keyValue)
        {
            warehouseApp.DeleteForm(keyValue);
            return Success("删除成功！");
        }
        #endregion

        #region 货架列表
        public ActionResult ShelfList()
        {
            return View();
        }

        public ActionResult GetShelfGridJson(Pagination pagination, string parentId, string keyword)
        {
            if (string.IsNullOrWhiteSpace(parentId))
            {
                return Content(new
                {
                    rows = new List<object> { },
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records
                }.ToJson());
            }
            var data = warehouseApp.GetList();

            data = data.Where(t => t.F_ParentId == parentId).ToList();
            data = data.Where(t => t.F_Type == null)?.ToList();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                data = data.Where(t => t.F_FullName.Contains(keyword)).ToList();
            }

            var result = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(result.ToJson());
        }

        public ActionResult ShelfEdit()
        {
            return View();
        }
        #endregion

    }
}
