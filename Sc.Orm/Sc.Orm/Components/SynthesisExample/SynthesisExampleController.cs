using System.Diagnostics;
using System.Web.Mvc;
using Sc.Orm.Components.SynthesisExample.Models;
using Sc.Orm.Components.SynthesisExample.Models.UserDefined;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace Sc.Orm.Components.SynthesisExample
{
    public class SynthesisExampleController : Controller
    {
        public ActionResult New()
        {

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                var temp = Sitecore.Context.Item.As<IPageItem>();
            }

            watch.Stop();

            var view = new SynthesisExampleIndexView();
            view.Watch = watch;
            view.Title = "New";
            return View("Index", view);

        }

        public ActionResult RenderFields()
        {


            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var temp = Sitecore.Context.Item.As<IPageItem>();

                var r1 = temp.SingleLineText.RenderedValue; 
                var r2 = temp.RichText.RenderedValue; 
                var r3 = temp.Image.RenderedValue;
                var r11 = temp.SingleLineText.RenderedValue; 
                var r22 = temp.RichText.RenderedValue;
                var r33 = temp.Image.RenderedValue;
            }

            watch.Stop();

            var view = new SynthesisExampleIndexView();
            view.Watch = watch;
            view.Title = "RenderFields";
            return View("Index", view);
        }

        public ActionResult Children()
        {
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var temp = Sitecore.Context.Item.As<IPageWithChildrenItem>();

                foreach (var child in temp.Children)
                {

                }
            }

            watch.Stop();

            var view = new SynthesisExampleIndexView();
            view.Watch = watch;
            view.Title = "Children";
            return View("Index", view);
        }

        public ActionResult ChildrenWithFields()
        {

            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var temp = Sitecore.Context.Item.As<IPageWithChildrenItem>();


                foreach (var child in temp.Children)
                {
                    var cast = child as IPageItem;

                    var r1 = cast.SingleLineText.RenderedValue;
                    var r3 = cast.Image.RenderedValue;
                }
            }

            watch.Stop();

            var view = new SynthesisExampleIndexView();
            view.Watch = watch;
            view.Title = "ChildrenWithFields";
            return View("Index", view);
        }

        public ActionResult Menu()
        {
            var item = Sitecore.Context.Database.GetItem("/sitecore/content/home");

            return View(item.As<INavigationItem>());
        }
    }
}