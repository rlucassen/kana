namespace Kana.Web
{
    #region Usings

    using Castle.Core.Resource;
    using Castle.Facilities.Logging;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.MonoRail.Framework;
    using Castle.MonoRail.WindsorExtension;
    using Castle.Windsor;
    using Castle.Windsor.Configuration.Interpreters;
    using Castle.Windsor.Installer;

    #endregion

    public class KanaContainer : WindsorContainer
    {
        public KanaContainer()
            : base(new XmlInterpreter(new ConfigResource()))
        {
            Install(FromAssembly.This());
        }

        public class MonorailInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.AddFacility<MonoRailFacility>();

                container.Register(Classes.FromThisAssembly()
                                       .Where(c => typeof (IController).IsAssignableFrom(c)
                                                   || typeof (IFilter).IsAssignableFrom(c)
                                                   || typeof (ViewComponent).IsAssignableFrom(c))
                                       .LifestylePerWebRequest());
            }
        }

        public class LoggerInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
            }
        }

        public class ClientsInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
            }
        }
    }
}