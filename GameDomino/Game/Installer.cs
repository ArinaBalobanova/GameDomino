using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domino;
using Domino2;

namespace GameDomino.Game
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
                Component.For<Entry>().LifestyleTransient(),
                Component.For<IUserService>().ImplementedBy<UserService>().LifestyleTransient(),
                Component.For<IDominoGameService>().ImplementedBy<DominoGameService>().LifestyleTransient()
            );
        }
    }
}