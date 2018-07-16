using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fortis.Providers;

namespace Sc.Orm.Components.FortisExample
{
    public class ModelProvider : IModelAssemblyProvider
    {
        protected IEnumerable<Type> ModelTypes;
        private readonly object _lock = new object();

        public Assembly Assembly { get; }

        public virtual Type[] Types
        {
            get
            {
                lock (this._lock)
                {
                    if (this.ModelTypes == null)
                    {
                        this.ModelTypes = (IEnumerable<Type>)this.GetType().Assembly.GetTypes();
                    }
                    return this.ModelTypes.ToArray<Type>();
                }
            }
        }

    }
}