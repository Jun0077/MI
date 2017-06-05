using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MI.Domain.Entity.ProductManage;
using MI.Code;
using MI.Application.ProductManage;


namespace MI.Web.Areas.ProductManage.Controllers
{
    public class HomeController : ControllerBase
    {
        //
        // GET: /ProductManage/Home/

        private  ProductApp app = new ProductApp();
        public ActionResult SubmitForm(BI_ProductInfoEntity entity,string keyValue)
        {
            app.SubmitForm(entity, keyValue);
            return Success("操作成功");
        }

        public ActionResult GetGridJson(Pagination pagination, string productId, string keyword)
        {
            var list = app.GetGridList(pagination, productId, keyword);
            return Content(list.ToJson());
        }

        public ActionResult GetFormJson(string keyValue)
        {
            var entity = app.GetForm(keyValue);
            return Content(entity.ToJson());
        }

        public ActionResult DeleteForm(string keyValue)
        {
            if (string.IsNullOrWhiteSpace(keyValue))
                return Error("参数为空","");
            app.DeleteForm(keyValue);
            return Success("操作成功");
        }

    }
}
