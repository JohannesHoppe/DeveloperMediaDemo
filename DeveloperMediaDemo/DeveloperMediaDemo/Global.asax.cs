using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebNoteSinglePage.AppStart;

namespace WebNoteSinglePage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly MongoDbConfig _mongoDbConfig = new MongoDbConfig();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterLessBundles(BundleTable.Bundles);
            BundleConfig.RegisterScriptBundles(BundleTable.Bundles);

            _mongoDbConfig.Start();

            UnityConfig.RegisterUnity();
        }

        protected void Application_End()
        {
            _mongoDbConfig.Stop();
        }
    }
}