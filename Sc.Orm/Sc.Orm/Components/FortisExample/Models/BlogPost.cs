using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fortis.Model;
using Fortis.Model.Fields;
using Fortis.Providers;
using Sitecore.Data.Items;

namespace Sc.Orm.Components.FortisExample.Models
{

    [TemplateMapping("{34501A12-13F0-406B-AE93-6C9B9D2A2B38}", "InterfaceMap")]
    public partial interface IBlogPost : IItemWrapper
    {
        ITextFieldWrapper Title { get; }
        ITextFieldWrapper Author { get; }
        ITextFieldWrapper Content { get; }
        IDateTimeFieldWrapper DateTime { get; }
        IImageFieldWrapper Image { get; }
    }

    [TemplateMapping("{34501A12-13F0-406B-AE93-6C9B9D2A2B38}")]
    public class BlogPost : ItemWrapper, IBlogPost
    {
        public BlogPost(Item item, ISpawnProvider spawnProvider)
            : base(item, spawnProvider)
        { }

        public ITextFieldWrapper Title
        {
            get { return GetField<TextFieldWrapper>("Title"); }
        }

        public ITextFieldWrapper Author
        {
            get { return GetField<TextFieldWrapper>("Author"); }
        }

        public ITextFieldWrapper Content
        {
            get { return GetField<TextFieldWrapper>("Content"); }
        }

        public IDateTimeFieldWrapper DateTime
        {
            get { return GetField<DateTimeFieldWrapper>("DateTime"); }

        }

        public IImageFieldWrapper Image
        {
            get { return GetField<ImageFieldWrapper>("Image"); }
        }
    }
}