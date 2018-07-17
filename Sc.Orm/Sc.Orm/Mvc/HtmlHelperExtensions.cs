using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc;

namespace Sc.Orm.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString TimedController(this HtmlHelper helper, string controller, string action)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = helper.Sitecore().Controller(controller, action);
            stopwatch.Stop();


            var html = $"<p><strong> Rendering Time: {stopwatch.ElapsedMilliseconds}</strong></p>";

            return new HtmlString($"{html} {result.ToString()} ");

        }
    }
}