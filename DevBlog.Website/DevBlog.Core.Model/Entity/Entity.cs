using DevBlog.Core.Model.Marker;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.Core.Model.Entity
{
    public abstract class Entity : IEntity
    {
        public virtual Guid Id { get; private set; }

        public override int GetHashCode() => Id.GetHashCode();

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
