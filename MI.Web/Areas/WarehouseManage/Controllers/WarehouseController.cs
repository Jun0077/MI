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

    }
}
