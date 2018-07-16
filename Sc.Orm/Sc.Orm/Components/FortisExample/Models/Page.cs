using Fortis.Model;
using Fortis.Model.Fields;
using Fortis.Providers;
using Sitecore.Data.Items;

namespace Sc.Orm.Components.FortisExample.Models
{
    [TemplateMapping("{FCF2D2CC-321A-4AF1-B6A9-3ECE7474BB0B}", "InterfaceMap")]
    public partial interface IPage : IItemWrapper
    {
        ITextFieldWrapper SingleLineText { get; }
        IRichTextFieldWrapper RichText { get; }
        IImageFieldWrapper Image { get; }
        IListFieldWrapper Tree { get; }
    }

    [TemplateMapping("{FCF2D2CC-321A-4AF1-B6A9-3ECE7474BB0B}")]
    public partial class Page : ItemWrapper, IPage
    {
        public Page(Item item, ISpawnProvider spawnProvider)
            : base(item, spawnProvider)
        { }

        public ITextFieldWrapper SingleLineText
        {
            get { return GetField<TextFieldWrapper>("SingleLineText"); }
        }

        public IRichTextFieldWrapper RichText
        {
            get { return GetField<RichTextFieldWrapper>("RichText"); }
        }

        public IImageFieldWrapper Image
        {
            get { return GetField<ImageFieldWrapper>("Image"); }
        }
        public IListFieldWrapper Tree
        {
            get { return GetField<ListFieldWrapper>("Tree"); }
        }
    }

    [TemplateMapping("{A1BE42F9-C23A-4BD4-B998-B5CCF0F9EADA}", "InterfaceMap")]
    public partial interface IPageWithChildren : IItemWrapper { }

    [TemplateMapping("{A1BE42F9-C23A-4BD4-B998-B5CCF0F9EADA}")]
    public class PageWithChildren : ItemWrapper, IPageWithChildren
    {
        public PageWithChildren(Item item, ISpawnProvider spawnProvider)
            : base(item, spawnProvider)
        { }
    }
}
