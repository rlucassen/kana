namespace Kana.Web
{
    #region Usings

    using System;
    using System.Web;
    using Castle.MonoRail.Framework;
    using Castle.MonoRail.Framework.Configuration;
    using Castle.MonoRail.Framework.Container;
    using Castle.MonoRail.Framework.Helpers.ValidationStrategy;
    using Castle.MonoRail.Framework.JSGeneration;
    using Castle.MonoRail.Framework.JSGeneration.jQuery;
    using Castle.MonoRail.Framework.Routing;
    using Castle.Windsor;
    using Controllers;

    #endregion

    public class Global : HttpApplication, IContainerAccessor, IMonoRailContainerEvents, IMonoRailConfigurationEvents
    {
        private static IWindsorContainer container;

        #region IContainerAccessor Members

        public IWindsorContainer Container => container;

        #endregion

        #region IMonoRailConfigurationEvents Members

        public void Configure(IMonoRailConfiguration configuration)
        {
            configuration.JSGeneratorConfiguration.AddLibrary("jquery-1.8.2", typeof (JQueryGenerator)).AddExtension(
                typeof (CommonJSExtension)).ElementGenerator.AddExtension(typeof (JQueryElementGenerator)).Done.
                BrowserValidatorIs(typeof (JQueryValidator)).SetAsDefault();
        }

        #endregion

        #region IMonoRailContainerEvents Members

        public void Created(IMonoRailContainer container)
        {
        }

        public void Initialized(IMonoRailContainer container)
        {
        }

        #endregion

        protected void Application_Start(object sender, EventArgs e)
        {
            container = new KanaContainer();

            RoutingModuleEx.Engine.Add(new PatternRoute("/")
                                           .DefaultForController().Is<HomeController>()
                                           .DefaultForAction().Is("index"));

            RoutingModuleEx.Engine.Add(
                new PatternRoute("/<controller>")
                    .DefaultForController().Is("home")
                    .DefaultForAction().Is("index")
            );

            RoutingModuleEx.Engine.Add(
                new PatternRoute("/<controller>/<action>")
                    .DefaultForController().Is("home")
                    .DefaultForAction().Is("index")
            );

            RoutingModuleEx.Engine.Add(
                new PatternRoute("/<area>/<controller>/<action>")
                    .DefaultForArea().Is("admin")
                    .DefaultForController().Is("home")
                    .DefaultForAction().Is("index")
            );
        }

        protected void Application_End(object sender, EventArgs e)
        {
            container?.Dispose();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
        }
    }
}