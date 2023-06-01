using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkflowR.Workflows.Domain.Tasking;
using WorkflowR.Workflows.Infrastructure.EF.Configs;
using WorkflowR.Workflows.Infrastructure.MediatR;

namespace WorkflowR.Workflows.Infrastructure.EF.Contexts
{
    public sealed class WorkflowsWriteDbContext : DbContext
    {
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<Domain.Tasking.Task> Tasks { get; set; }
        
        public readonly IMediator _mediator;

        public WorkflowsWriteDbContext(
            DbContextOptions<WorkflowsWriteDbContext> options,
            IMediator mediator)
                : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("workflows");

            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<Workflow>(configuration);
            modelBuilder.ApplyConfiguration<Domain.Tasking.Task>(configuration);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken =  default)
        {
            await _mediator.DispatchDomainEventsAsync(this);

            await SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}