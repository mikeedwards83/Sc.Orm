using System.Diagnostics;
using System.Web.Mvc;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sc.Orm.Components.GlassExample.Models;
using Page = Sc.Orm.Components.GlassExample.Models.Page;

namespace Sc.Orm.Components.GlassExample
{
    public class GlassExampleController : Controller
    {
        public ActionResult New()
        {
            var context = new MvcContext();

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                var temp = context.GetContextItem<Page>();
            }

            watch.Stop();

            var view = new GlassExampleIndexView();
            view.Watch = watch;
            view.Title = "New";

            return View("Index", view);

        }

        public ActionResult RenderFields()
        {
            var context = new MvcContext();
            var page = context.GetContextItem<Page>();
            var glassHtml = new GlassHtml(context.SitecoreService);

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                var temp = context.GetContextItem<Page>();

                var r1 = glassHtml.Editable(temp, x => x.SingleLineText);
                var r2 = glassHtml.Editable(temp, x => x.RichText);
                var r3 = glassHtml.Editable(temp, x => x.Image);
                var r11 = glassHtml.Editable(temp, x => x.SingleLineText);
                var r22 = glassHtml.Editable(temp, x => x.RichText);
                var r33 = glassHtml.Editable(temp, x => x.Image);


            }

            watch.Stop();

            var view = new GlassExampleIndexView();
            view.Watch = watch;
            view.Title = "RenderFields";

            return View("Index", view);
        }

        public ActionResult Children()
        {
            var context = new MvcContext();
            var page = context.GetContextItem<Page>();
            var glassHtml = new GlassHtml(context.SitecoreService);

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                var temp = context.GetContextItem<PageWithChildren>();
                foreach(var child in temp.Children) { }
            }

            watch.Stop();

            var view = new GlassExampleIndexView();
            view.Watch = watch;
            view.Title = "Children";

            return View("Index", view);
        }

        public ActionResult ChildrenWithFields()
        {
            var context = new MvcContext();
            var page = context.GetContextItem<Page>();
            var glassHtml = new GlassHtml(context.SitecoreService);

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                var temp = context.GetContextItem<PageWithChildrenAndFields>();
                foreach (var child in temp.Children)
                {
                    var r1 = glassHtml.Editable(child, x => x.SingleLineText);
                    var r3 = glassHtml.Editable(child, x => x.Image);
                }
            }

            watch.Stop();

            var view = new GlassExampleIndexView();
            view.Watch = watch;
            view.Title = "Children";

            return View("Index", view);
        }

        public ActionResult Menu()
        {
            var context = new MvcContext();
            var model = context.SitecoreService.GetItem<Navigation>("/sitecore/content/home");

            return View(model);
        }

        public ActionResult BlogPost()
        {
            var context = new MvcContext();
            var model = context.SitecoreService.GetItem<BlogPost>("/sitecore/content/home/blogpost");

            return View(model);
        }

        public ActionResult Menu_Cached()
        {
            var context = new MvcContext();
            var model = context.SitecoreService.GetItem<Navigation>("/sitecore/content/home",x=>x.CacheEnabled());

            return View("Menu",model);
        }

        public ActionResult BlogPost_Cached()
        {
            var context = new MvcContext();
            var model = context.SitecoreService.GetItem<BlogPost>("/sitecore/content/home/blogpost", x => x.CacheEnabled());

            return View("BlogPost",model);
        }
    }
}