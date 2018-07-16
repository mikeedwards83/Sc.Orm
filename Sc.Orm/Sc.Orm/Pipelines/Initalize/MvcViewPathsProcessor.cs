using System.Linq;
using System.Web.Mvc;
using Sitecore.Pipelines;

namespace Sc.Orm.Pipelines.Initalize
{
    public class MvcViewPathsProcessor
    {
        public void Process(PipelineArgs args)
        {
            var engine = ViewEngines.Engines.OfType<RazorViewEngine>().FirstOrDefault();

            if (engine == null)
            {
                return;
            }
            var viewLocationTemplates = engine.ViewLocationFormats.ToList();

            viewLocationTemplates.Add("~/Components/{1}/Views/{0}.cshtml");
            engine.ViewLocationFormats = viewLocationTemplates.ToArray();
        }
    }
}