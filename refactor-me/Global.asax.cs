using Ninject;
using Ninject.Web.Common.WebHost;
using refactor_me.Data.Infra.DependencyManagement;
using refactor_me.Data.Models.Products;
using refactor_me.Infra.DependencyManagement;
using refactor_me.Models;
using refactor_me.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace refactor_me
{
    /// <summary>
    /// WebApiApplication 
    /// </summary>
    public class WebApiApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            GlobalConfiguration.Configuration.DependencyResolver =
                                     new LocalNinjectDependencyResolver(kernel);
            return kernel;
        }

    }
    /// <summary>
    /// LocalNinjectDependencyResolver
    /// </summary>
    class LocalNinjectDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public LocalNinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op.
        }
    }
}
