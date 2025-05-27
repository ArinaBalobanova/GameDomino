using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domino2;

namespace Domino
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ApplicationDbContext>().LifestyleTransient(),
                Component.For<IUserService>().ImplementedBy<UserService>().LifestyleTransient(),
                Component.For<Entry>().LifestyleTransient(),
                Component.For<Registration>().LifestyleTransient(),

                Component.For<MainWindow>().UsingFactoryMethod(kernel =>
                {
                    return new MainWindow(Guid.Empty);
                }).LifestyleTransient()
            );
        }
    }
}
