using System.Web.Mvc;

namespace MI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandlerErrorAttribute());
        }
    }
}