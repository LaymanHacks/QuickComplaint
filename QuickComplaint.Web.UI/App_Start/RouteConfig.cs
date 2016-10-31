using System.Web.Mvc;
using System.Web.Routing;

namespace QuickComplaint.Web.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Complaint", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}