using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DeveloperMediaDemo.Models;

namespace DeveloperMediaDemo.AppStart
{
    /// <summary>
    /// Wires up the Inversion of Control framework (Autofac)
    /// </summary>
    public static class ContainerConfig
    {
        public static void RegisterDependencyResolver()
        {
            var builder = new ContainerBuilder();

            // add more types here!
            builder.RegisterType<NoteRepository>().As<INoteRepository>()
                   .InstancePerHttpRequest()
                   .InstancePerApiRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); 

            IContainer container = builder.Build();

            SetMvcResolver(container);
            SetWebApiResolver(container);
        }

        /// <summary>
        /// Set the dependency resolver for Web API.
        /// </summary>
        private static void SetMvcResolver(ILifetimeScope container)
        {
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }

        /// <summary>
        /// Set the dependency resolver for MVC.
        /// </summary>
        private static void SetWebApiResolver(ILifetimeScope container)
        {
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}