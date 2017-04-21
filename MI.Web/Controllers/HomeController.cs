





using MI.Application.SystemManage;
using MI.Code;
using MI.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace MI.Web.Controllers
{
     [HandlerLogin]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}
