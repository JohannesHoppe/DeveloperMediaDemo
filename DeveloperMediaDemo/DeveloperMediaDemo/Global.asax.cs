using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DeveloperMediaDemo.AppStart;

namespace DeveloperMediaDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterLessBundles(BundleTable.Bundles);
            BundleConfig.RegisterScriptBundles(BundleTable.Bundles);
        }
    }
}