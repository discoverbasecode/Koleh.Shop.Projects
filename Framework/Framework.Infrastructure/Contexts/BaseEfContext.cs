using Framework.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Framework.Infrastructure.Contexts;

public class BaseEfContext<T>(DbContextOptions<T> options, IMediator mediator) : DbContext(options)
    where T : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(T).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var modifiedEntities = GetModifiedEntities();
        var res = await base.SaveChangesAsync(cancellationToken);
        await PublishEvents(modifiedEntities);
        return res;
    }

    private List<AggregateRoot> GetModifiedEntities() =>
        ChangeTracker.Entries<AggregateRoot>()
            .Where(x => x.State != EntityState.Detached)
            .Select(c => c.Entity)
            .Where(c => c.DomainEvents.Any()).ToList();

    private async Task PublishEvents(List<AggregateRoot> modifiedEntities)
    {
        foreach (var entity in modifiedEntities)
        {
            var events = entity.DomainEvents;
            foreach (var domainEvent in events)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}