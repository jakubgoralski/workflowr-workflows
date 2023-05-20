using MediatR;
using WorkflowR.Workflows.Domain.Abstraction;
using WorkflowR.Workflows.Infrastructure.EF.Contexts;

namespace WorkflowR.Workflows.Infrastructure.MediatR
{
    public static class Extensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, WorkflowsWriteDbContext workflowsWriteDbContext)
        {
            IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity>> domainEntities = workflowsWriteDbContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Events is not null && x.Entity.Events.Any());

            List<INotification> domainEvents = domainEntities
                .SelectMany(x => x.Entity.Events)
                .ToList();

            domainEntities.ToList().ForEach(x => x.Entity.CleanEvents());

            foreach (INotification domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}
