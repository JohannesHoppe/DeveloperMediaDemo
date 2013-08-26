using System.Web.Http;
using DeveloperMediaDemo.Code;

namespace DeveloperMediaDemo.AppStart
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // enables Attribute routing from (Web API 2)
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new ValidateModelAttribute());
        }
    }
}
