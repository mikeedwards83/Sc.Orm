using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace Sc.Orm.Components.GlassExample.Models
{
    public class Page
    {
        public virtual string SingleLineText { get; set; }
        public virtual string RichText { get; set; }
        public virtual Image Image { get; set; }
        public virtual IEnumerable<Page> Tree { get; set; }

    }

    public class PageWithChildren{

        [SitecoreChildren]
        public virtual IEnumerable<Child> Children { get; set; }
    }

    public class Child
    {
        
    }

    public class PageWithChildrenAndFields
    {

        [SitecoreChildren]
        public virtual IEnumerable<ChildWithFields> Children { get; set; }
    }

    public class ChildWithFields
    {
        public virtual string SingleLineText { get; set; }
        public virtual Image Image { get; set; }
    }
}