using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domino2;
using GameDomino;

namespace Domino
{
    /// <summary>
    /// Класс для внедрения зависимостей(DI)
    /// </summary>
    public class WindsorInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Регистраия компонентов для Windsor container
        /// </summary>
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
                }).LifestyleTransient(),
                Component.For<InviteForm>().LifestyleTransient()
            );
        }
    }
}
