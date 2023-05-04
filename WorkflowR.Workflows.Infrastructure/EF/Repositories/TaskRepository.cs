using WorkflowR.Workflows.Domain.Tasking;
using WorkflowR.Workflows.Infrastructure.EF.Contexts;

namespace WorkflowR.Workflows.Infrastructure.EF.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly WorkflowsWriteDbContext _workflowsDbContext;

        public TaskRepository(WorkflowsWriteDbContext workflowsDbContext)
        {
            _workflowsDbContext = workflowsDbContext;
        }

        public async System.Threading.Tasks.Task CreateAsync(Domain.Tasking.Task task)
        {
            await _workflowsDbContext.Tasks.AddAsync(task);
            await _workflowsDbContext.SaveChangesAsync();
        }

        public Domain.Tasking.Task ReadAsync(Guid guid)
        {
            return _workflowsDbContext.Tasks.FirstOrDefault(x => x.Id.Equals(guid));
        }

        public async System.Threading.Tasks.Task UpdateAsync(Domain.Tasking.Task task)
        {
            _workflowsDbContext.Tasks.Update(task);
            await _workflowsDbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(Guid guid)
        {
            var task = _workflowsDbContext.Tasks.FirstOrDefault(x => x.Id.Equals(guid));

            _workflowsDbContext.Tasks.Remove(task);
            await _workflowsDbContext.SaveChangesAsync();
        }
    }
}