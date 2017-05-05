using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MI.Domain.Entity.SupplierManage;
using MI.Application.SupplierManage;
using MI.Code;


namespace MI.Web.Areas.SupplierManage.Controllers
{
    public class HomeController : ControllerBase
    {
        //
        // GET: /SupplierManage/Home/

        private SupplierInfoApp app = new SupplierInfoApp();


        public ActionResult SubmitForm(SupplierInfoEntity entity,string keyValue)
        {
            entity.F_Id = keyValue;
            app.SubmitForm(entity);
            return Success("操作成功");
        }

        public ActionResult GetGridJson(Pagination pagination, string keyWork)
        {
            var list = app.GetList(pagination, keyWork);
            var result = new
            {
                rows = list,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(result.ToJson());
        }

        public ActionResult GetFormJson(string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
                return Content("null");
            return Content(app.GetForm(keyValue).ToJson());
        }

        public ActionResult DeleteForm(string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
            {
                return Error("删除的供应商不存在","");
            }

            app.DeleteForm(keyValue);
            return Success("操作成功!");
        }

    }
}
