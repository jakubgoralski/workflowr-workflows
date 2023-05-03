using Microsoft.EntityFrameworkCore;

namespace WorkflowR.Workflows.Infrastructure.EF.Contexts
{
    public sealed class WorkflowsWriteDbContext : DbContext
    {
        public DbSet<Domain.Tasking.Task> Tasks { get; set; }

        public WorkflowsWriteDbContext(DbContextOptions<WorkflowsWriteDbContext> options) : base(options)
        {
        }
    }
}