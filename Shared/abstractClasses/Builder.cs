using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shared.abstractClasses
{
    public abstract class Builder
    {
        protected string Name = string.Empty;
        protected List<Task> builderResources = null;

        public virtual Task<Part> BuildPart() { throw new NotImplementedException(); }
        public virtual Task<bool> RunBuilders() { throw new NotImplementedException(); }
    }
}
