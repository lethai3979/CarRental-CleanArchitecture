using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class BaseEntity<EntityId> where EntityId : Primitives.EntityId 
    {
        private readonly List<INotification> _domainEvents = new List<INotification>();
        public IReadOnlyCollection<INotification> domainEvents => _domainEvents.AsReadOnly();

        protected BaseEntity(EntityId id)
        {
            this.Id = id;
        }

        public EntityId Id { get; set; }
        public bool IsDeleted { get; set; }

        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearEvents() 
        {
            _domainEvents.Clear();
        }
    }
}
