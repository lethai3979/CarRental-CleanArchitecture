using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public abstract class BaseEntity<EntityId>
    {
        protected BaseEntity(EntityId id)
        {
            Id = id;
        }

        public EntityId Id { get; set; }
        public bool IsDeleted { get; set; }

    }
}
