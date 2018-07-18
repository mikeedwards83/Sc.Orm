using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace Sc.Orm.Components.GlassExample.Models
{
    [SitecoreType(AutoMap = true)]
    public class BlogPost
    {
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual Image Image { get; set; }
    }
}