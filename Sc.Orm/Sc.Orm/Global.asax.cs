using System;
using Fortis.Model;
using Fortis.Mvc.Providers;
using Fortis.Providers;
using Sc.Orm.Components.FortisExample;

namespace Sc.Orm
{
    public class Global : System.Web.HttpApplication
    {
        public static IItemFactory FortisFactory { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            // Register Fortis
            var contextProvider = new ContextProvider();
            var modelAssemblyProvider = new ModelProvider();
            var templateMapProvider = new TemplateMapProvider(modelAssemblyProvider);
            var spawnProvider = new SpawnProvider(templateMapProvider);

            

            var itemFactory = new ItemFactory(contextProvider, spawnProvider);
            FortisFactory = itemFactory;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}