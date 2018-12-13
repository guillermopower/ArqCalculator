using System.Web;
using System.Web.Mvc;

namespace Tecnologia1UNDAV
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
