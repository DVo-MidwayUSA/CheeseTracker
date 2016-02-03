using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CheeseTracker.AspNetMvc.Services;
using CheeseTracker.Common.Services;

namespace CheeseTracker.AspNetMvc.App.Injection.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ICheeseService>()
                    .ImplementedBy<CheeseService>());

            container.Register(
                Component
                    .For<IImageConverterService>()
                        .ImplementedBy<ImageConverterService>());
        }
    }
}