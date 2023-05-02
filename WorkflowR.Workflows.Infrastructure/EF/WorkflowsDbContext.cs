using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WorkflowR.Workflows.Infrastructure.Options;

namespace WorkflowR.Workflows.Infrastructure.EF
{
    public class WorkflowsDbContext : DbContext
    {
        private readonly ConnectionStringOption _options;
        public DbSet<Domain.Tasking.Task> Tasks { get; set; }

        public WorkflowsDbContext(IOptions<ConnectionStringOption> options)
        {
            _options = options.Value;
        }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_options.ConnectionString);
        }
    }
}
