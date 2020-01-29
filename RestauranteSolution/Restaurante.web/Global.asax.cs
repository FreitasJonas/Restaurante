using Restaurante.access;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Restaurante.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new SimpleInjector.Container();

            container.Register<IDao, Db>();
            container.Register<Db>(delegate () { return new Db(); }, Lifestyle.Singleton);

            container.Verify();

            DependencyResolver.SetResolver(
               new SimpleInjectorDependencyResolver(container));

        }
    }
}
