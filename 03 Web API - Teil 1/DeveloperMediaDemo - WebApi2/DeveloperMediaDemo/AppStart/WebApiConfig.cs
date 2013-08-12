using System.Web.Http;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

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


            #region you don't want to read that
            // see: http://www.strathweb.com/2013/04/asp-net-web-api-and-greedy-query-string-parameter-binding/
            // fixes the problem of greedy query strings in ASP.NET Web API
            // if you config this: /api/test/hello/world
            // this will also be possible (default route): /api/test?p1=hello&p2=world
            //config.Services.Replace(typeof (ValueProviderFactory), new RouteDataValueProviderFactory());

            // BUT when using AttributeRouting:
            // ApiExplorer Shows Funky Extraneous Routes (#102)
            // Solution: none
            // see: https://github.com/mccalltd/AttributeRouting/issues/96

            // I just fixed the API explorer...
            #endregion
        }
    }
}
