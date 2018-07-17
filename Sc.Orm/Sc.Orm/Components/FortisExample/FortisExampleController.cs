using System.Diagnostics;
using System.Web.Mvc;
using Sc.Orm.Components.FortisExample.Models;

namespace Sc.Orm.Components.FortisExample
{
    public class FortisExampleController : Controller
    {

        public ActionResult New()
        {
            var factory = Global.FortisFactory;

            var item = factory.GetContextItem<IPage>();

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                var temp = factory.GetContextItem<IPage>();
            }

            watch.Stop();

            var view = new FortisExampleIndexView();
            view.Watch = watch;
            view.Title = "New";

            return View("Index", view);

        }

        public ActionResult RenderFields()
        {

            var factory = Global.FortisFactory;

            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var temp = factory.GetContextItem<IPage>();
                var r1 = temp.SingleLineText.Render();
                var r2 = temp.RichText.Render();
                var r3 = temp.Image.Render();
                var r11 = temp.SingleLineText.Render();
                var r22 = temp.RichText.Render();
                var r33 = temp.Image.Render();

            }

            watch.Stop();

            var view = new FortisExampleIndexView();
            view.Watch = watch;
            view.Title = "RenderFields";

            return View("Index", view);
        }

        public ActionResult Children()
        {

            var factory = Global.FortisFactory;

            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var temp = factory.GetContextItem<IPageWithChildren>();
                foreach (var child in temp.Children<IPage>())
                {

                }

            }

            watch.Stop();

            var view = new FortisExampleIndexView();
            view.Watch = watch;
            view.Title = "Children";

            return View("Index", view);
        }


        public ActionResult ChildrenWithFields()
        {

            var factory = Global.FortisFactory;

            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var temp = factory.GetContextItem<IPageWithChildren>();
                foreach (var child in temp.Children<IPage>())
                {
                    var r1 = child.SingleLineText.Render();
                    var r3 = child.Image.Render();
                }

            }

            watch.Stop();

            var view = new FortisExampleIndexView();
            view.Watch = watch;
            view.Title = "ChildrenWithFields";

            return View("Index", view);
        }

        public ActionResult Menu()
        {

            var factory = Global.FortisFactory;

            var model =factory.Select<INavigation>("/sitecore/content/home");
            return View(model);
        }
    }
}