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
            long totalMs = 0;
            long totalTicks = 0;
           
            int count = 100;

            var result = helper.LoopRendering(100, controller, action, out totalMs, out totalTicks);

            long averageMs = totalMs / count;
            long averageTicks = totalTicks / count;

            var html = $"<p><strong> Rendering Time ({count}): {averageMs} ({totalMs}) ms - {averageTicks} ({totalTicks}) ticks</strong></p>";

            return new HtmlString($"{html} {result.ToString()} ");

        }
        private static HtmlString LoopRendering(this HtmlHelper helper, int count, string controller, string action, out long totalMs, out long totalTicks)
        {
            HtmlString result = null;
            totalTicks = 0;
            totalMs = 0;

            for (int i = 0; i < count; i++)
            {
                var stopwatch = Stopwatch.StartNew();
                result = helper.Sitecore().Controller(controller, action);
                stopwatch.Stop();

                totalMs += stopwatch.ElapsedMilliseconds;
                totalTicks += stopwatch.ElapsedTicks;
            }

            return result;


        }
    }
}