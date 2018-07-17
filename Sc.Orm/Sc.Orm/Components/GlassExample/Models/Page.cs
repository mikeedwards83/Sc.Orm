using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace Sc.Orm.Components.GlassExample.Models
{
    [SitecoreType(AutoMap = true)]
    public class Page
    {
        public virtual string SingleLineText { get; set; }
        public virtual string RichText { get; set; }
        public virtual Image Image { get; set; }
        public virtual IEnumerable<Page> Tree { get; set; }

    }

    [SitecoreType(AutoMap = true)]
    public class PageWithChildren{

        [SitecoreChildren]
        public virtual IEnumerable<Child> Children { get; set; }
    }

    [SitecoreType(AutoMap = true)]
    public class Child
    {
        
    }

    [SitecoreType(AutoMap = true)]
    public class PageWithChildrenAndFields
    {

        [SitecoreChildren]
        public virtual IEnumerable<ChildWithFields> Children { get; set; }
    }

    [SitecoreType(AutoMap = true)]
    public class ChildWithFields
    {
        public virtual string SingleLineText { get; set; }
        public virtual Image Image { get; set; }
    }
}