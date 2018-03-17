using Castle.Windsor;

namespace Api.App.Infrastructure.Api.Dependency
{
    public class IoC
    {
        static IoC()
        {
            Container = new WindsorContainer();
        }

        // For testing purpose
        protected static void Reset()
        {
            Container = new WindsorContainer();
        }

        public static WindsorContainer Container { get; private set; }
    }
}