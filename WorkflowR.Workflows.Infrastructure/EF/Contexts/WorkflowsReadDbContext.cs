using Microsoft.EntityFrameworkCore;
using WorkflowR.Workflows.Infrastructure.EF.Configs;
using WorkflowR.Workflows.Infrastructure.EF.ReadModels;

namespace WorkflowR.Workflows.Infrastructure.EF.Contexts
{
    public sealed class WorkflowsReadDbContext : DbContext
    {
        public DbSet<WorkflowReadModel> Workflows { get; set; }
        public DbSet<TaskReadModel> Tasks { get; set; }

        public WorkflowsReadDbContext(DbContextOptions<WorkflowsReadDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("workflows");

            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<TaskReadModel>(configuration);
            modelBuilder.ApplyConfiguration<WorkflowReadModel>(configuration);
        }
    }
}
