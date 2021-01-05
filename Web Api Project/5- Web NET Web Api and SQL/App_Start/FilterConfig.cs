using System.Web;
using System.Web.Mvc;

namespace _5__Web_NET_Web_Api_and_SQL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
