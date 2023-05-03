using Microsoft.EntityFrameworkCore;

namespace WorkflowR.Workflows.Infrastructure.EF
{
    public class WorkflowsDbContext : DbContext
    {
        public DbSet<Domain.Tasking.Task> Tasks { get; set; }

        public WorkflowsDbContext(DbContextOptions<WorkflowsDbContext> options) : base(options)
        {
        }
    }
}