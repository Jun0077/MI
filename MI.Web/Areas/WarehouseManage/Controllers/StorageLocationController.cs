using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MI.Application.WarehouseManage;
using MI.Domain.Entity.WarehouseManage;
using MI.Code;

namespace MI.Web.Areas.WarehouseManage.Controllers
{
    public class StorageLocationController : ControllerBase
    {
        private StorageLocationApp app = new StorageLocationApp();

        //[HandlerAjaxOnly]
        [HttpGet]
        /// <summary>
        /// 获取库位列表信息
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        public ActionResult GetListJson(string warehouseId)
        {
            var list = app.GetList(warehouseId);
            var data = list?.GroupBy(_ => _.F_LayerNumber);
            return Content(data.OrderBy(_=>_.Key).ToJson());
        }

        

        public ActionResult SubmitBatch(string warehouseId)
        {
            if (string.IsNullOrWhiteSpace(warehouseId))
                throw new Exception("货架货ID为空");
            app.SubmitBatch(warehouseId);
            return Success("创建库位列表信息成功！");
        }


        public ActionResult GetFormJson(string keyValue)
        {
            var data = app.GetForm(keyValue);
            if (data == null)
                throw new Exception("F_Id:"+keyValue+"库位信息不存在!");
            return Content(data.ToJson());
        }


        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(StorageLocationEntity entity, string keyValue)
        {
            app.SubmitForm(entity, keyValue);
            return Success("操作成功。");
        }

    }
}
