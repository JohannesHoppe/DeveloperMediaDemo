using System.Web.Http;
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
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterLessBundles(BundleTable.Bundles);
            BundleConfig.RegisterScriptBundles(BundleTable.Bundles);

            DisableXmlFormatter();
        }

        /// <summary>
        /// Disables the Xml Formatter in ASP.NET Web API for easier debugging
        /// </summary>
        private static void DisableXmlFormatter()
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
			// plus: nicer formating!
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.Indent = true;
        }
    }
}