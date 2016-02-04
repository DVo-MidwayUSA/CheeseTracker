using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CheeseTracker.Common.DataAccess;

namespace CheeseTracker.AspNetMvc.App.Injection.Installers
{
    public class DataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnitOfWork>()
                    .ImplementedBy<DataClassesDataContext>());
        }
    }
}