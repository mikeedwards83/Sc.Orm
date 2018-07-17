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

    [TemplateMapping("{3775B2B2-24D0-4FE7-9FDE-9D72795C1308}", "InterfaceMap")]
    public partial interface INavigation : IItemWrapper
    {
        ITextFieldWrapper Title { get; }

    }

    [TemplateMapping("{3775B2B2-24D0-4FE7-9FDE-9D72795C1308}")]
    public class Navigation : ItemWrapper, INavigation
    {
        public Navigation(Item item, ISpawnProvider spawnProvider)
            : base(item, spawnProvider)
        { }

        public ITextFieldWrapper Title
        {
            get { return GetField<TextFieldWrapper>("Title"); }
        }

    }
}