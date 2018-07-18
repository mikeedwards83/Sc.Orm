using System.Diagnostics;
using System.Web.Mvc;
using Sc.Orm.Components.SitecoreExample.Models;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Presentation;

namespace Sc.Orm.Components.SitecoreExample
{
    public class SitecoreExampleController : Controller
    {
        public ActionResult New()
        {

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                var temp = Sitecore.Context.Item;
            }

            watch.Stop();

            var view = new SitecoreExampleIndexView();
            view.Watch = watch;
            view.Title = "New";
            return View("Index", view);

        }

        public ActionResult RenderFields()
        {

            var helper = new SitecoreHelper(new HtmlHelper(new ViewContext(), new ViewDataContainer(this.ViewData)));

            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var temp = Sitecore.Context.Item;

                var r1 = helper.Field("SingleLineText", temp);
                var r2 = helper.Field("RichText", temp);
                var r3 = helper.Field("Image", temp);
                var r11 = helper.Field("SingleLineText", temp);
                var r22 = helper.Field("RichText", temp);
                var r33 = helper.Field("Image", temp);
            }

            watch.Stop();

            var view = new SitecoreExampleIndexView();
            view.Watch = watch;
            view.Title = "RenderFields";
            return View("Index", view);
        }

        public ActionResult Children()
        {
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var temp = Sitecore.Context.Item;

                foreach (var child in temp.Children)
                {

                }
            }

            watch.Stop();

            var view = new SitecoreExampleIndexView();
            view.Watch = watch;
            view.Title = "Children";
            return View("Index", view);
        }

        public ActionResult ChildrenWithFields()
        {
            var helper = new SitecoreHelper(new HtmlHelper(new ViewContext(), new ViewDataContainer(this.ViewData)));

            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var temp = Sitecore.Context.Item;

                foreach (var child in temp.Children)
                {
                    var r1 = helper.Field("SingleLineText", child);
                    var r3 = helper.Field("Image", child);
                }
            }

            watch.Stop();

            var view = new SitecoreExampleIndexView();
            view.Watch = watch;
            view.Title = "ChildrenWithFields";
            return View("Index", view);
        }

        public ActionResult Menu()
        {
            var item = Sitecore.Context.Database.GetItem("/sitecore/content/home");

            return View(item);
        }
        public ActionResult BlogPost()
        {
            var item = Sitecore.Context.Database.GetItem("/sitecore/content/home/blogpost");

            return View(item);
        }
    }
}