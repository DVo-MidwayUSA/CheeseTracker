using Castle.Windsor;
using Castle.Windsor.Installer;
using CheeseTracker.AspNetMvc.App.Injection;
using System.Web.Mvc;
using System.Web.Routing;

namespace CheeseTracker.AspNetMvc.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapContainer();
        }

        protected void Application_End()
        {
            container.Dispose();
        }

        private static void BootstrapContainer()
        {
            container = new WindsorContainer()
                .Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
