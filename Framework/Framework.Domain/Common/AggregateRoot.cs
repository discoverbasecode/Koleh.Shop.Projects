using System.ComponentModel.DataAnnotations.Schema;
using Framework.Domain.Entities;

namespace Framework.Domain.Common;

public class AggregateRoot : BaseEntity
{
    private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();

    [NotMapped] public IEnumerable<BaseDomainEvent> DomainEvents => _domainEvents;

    public void AddDomainEvent(BaseDomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(BaseDomainEvent eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }
}