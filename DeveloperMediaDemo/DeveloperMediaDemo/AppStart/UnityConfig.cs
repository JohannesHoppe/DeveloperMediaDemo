using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace WebNoteSinglePage.AppStart
{
    public static class UnityConfig
    {
        public static void RegisterUnity()
        {
            IUnityContainer container = UnityContainerConfig.RegisterTypes();

            UnityDependencyResolver resolver = new UnityDependencyResolver(container);

            // for MVC Controllers
            DependencyResolver.SetResolver(resolver);

            // for WEB API Controllers
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
