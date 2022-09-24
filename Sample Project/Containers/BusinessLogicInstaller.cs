using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Sample_Project.Interfaces;
using Sample_Project.Repositories;

namespace Sample_Project.Containers
{
    public class BusinessLogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Registering containers
            container.Register(Component.For<IDbConnector>().ImplementedBy<DbConnector>().LifestyleTransient());
            container.Register(Component.For<IProducts>().ImplementedBy<ProductsRepository>().LifestyleTransient());
        }
    }
}