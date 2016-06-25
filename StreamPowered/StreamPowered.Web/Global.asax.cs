using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StreamPowered.Web.App_Start;

namespace StreamPowered.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            MapperConfig.RegisterMappings();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEnginesConfig.RegisterViewEngines(ViewEngines.Engines);
        }
    }
}
