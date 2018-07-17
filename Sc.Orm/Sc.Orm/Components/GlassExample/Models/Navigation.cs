using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Sc.Orm.Components.GlassExample.Models
{
    [SitecoreType(AutoMap = true)]
    public class Navigation
    {
        public virtual string Title { get; set; }
        public virtual string Url { get; set; }

        public virtual IEnumerable<Navigation> Children { get; set; }
    }
}