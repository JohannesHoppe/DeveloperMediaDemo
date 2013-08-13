using System.Web.Http;

namespace DeveloperMediaDemo.AppStart
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*
            config.Routes.MapHttpRoute(
                name: "SearchNoteApi",
                routeTemplate: "api/{controller}/{action}/{titlePart}",
                defaults: null,
                constraints: new { controller = "Note|OrMaybeAnotherController" }
            );
            */

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
