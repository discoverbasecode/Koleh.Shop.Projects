using MediatR;

namespace Framework.Domain.Common;

public abstract class BaseDomainEvent : INotification
{
    public DateTime CreationDate { get; protected set; } = DateTime.Now;
}