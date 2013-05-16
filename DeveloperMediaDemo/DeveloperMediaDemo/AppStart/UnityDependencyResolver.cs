using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.Unity;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

namespace WebNoteSinglePage.AppStart
{
    /// <summary>
    /// ASP.NET Web API beta ships with its own IDependencyResolver
    /// </summary>
    public sealed class UnityDependencyResolver : IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "No other way supported by Unity!")]
        private object SharedGetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "No other way supported by Unity!")]
        private IEnumerable<object> SharedGetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

        #region System.Web.Mvc.IDependencyResolver

        object System.Web.Mvc.IDependencyResolver.GetService(Type serviceType)
        {
            return SharedGetService(serviceType);
        }

        IEnumerable<object> System.Web.Mvc.IDependencyResolver.GetServices(Type serviceType)
        {
            return SharedGetServices(serviceType);
        }

        #endregion

        #region System.Web.Http.Dependencies.IDependencyResolver

        /// <summary>
        /// Creates a nested scope.
        /// </summary>
        System.Web.Http.Dependencies.IDependencyScope System.Web.Http.Dependencies.IDependencyResolver.BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityDependencyResolver(child);
        }

        /// <summary>
        /// Creates one instance of a specified type.
        /// </summary>
        object System.Web.Http.Dependencies.IDependencyScope.GetService(Type serviceType)
        {
            return SharedGetService(serviceType);
        }

        /// <summary>
        ///  Create a collection of objects of a specified type.
        /// </summary>
        IEnumerable<object> System.Web.Http.Dependencies.IDependencyScope.GetServices(Type serviceType)
        {
            return SharedGetServices(serviceType);
        }

        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        void IDisposable.Dispose()
        {
            _container.Dispose();
        }

        #endregion
    }
}
