using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MI.Web.Areas.SupplierManage
{
    public class SupplierManageAreaRegistration: AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SupplierManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              this.AreaName + "_Default",
              this.AreaName + "/{controller}/{action}/{id}",
              new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "MI.Web.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}