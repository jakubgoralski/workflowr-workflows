using Microsoft.EntityFrameworkCore;
using WorkflowR.Workflows.Infrastructure.EF.Configs;

namespace WorkflowR.Workflows.Infrastructure.EF.Contexts
{
    public sealed class WorkflowsWriteDbContext : DbContext
    {
        public DbSet<Domain.Tasking.Task> Tasks { get; set; }

        public WorkflowsWriteDbContext(DbContextOptions<WorkflowsWriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("workflows");

            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<Domain.Tasking.Task>(configuration);
        }
    }
}