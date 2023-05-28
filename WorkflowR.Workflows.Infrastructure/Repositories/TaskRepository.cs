using Microsoft.EntityFrameworkCore;
using WorkflowR.Workflows.Domain.Tasking;
using WorkflowR.Workflows.Infrastructure.EF.Contexts;

namespace WorkflowR.Workflows.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly WorkflowsWriteDbContext _workflowsDbContext;

        public TaskRepository(
            WorkflowsWriteDbContext workflowsDbContext)
        {
            _workflowsDbContext = workflowsDbContext;
        }

        public async System.Threading.Tasks.Task CreateAsync(Domain.Tasking.Task task)
        {
            await _workflowsDbContext.Tasks.AddAsync(task);
            await _workflowsDbContext.SaveEntitiesAsync();
        }

        public async Task<bool> ExistsAsync(Guid taskId)
        {
            return await _workflowsDbContext.Tasks.AnyAsync(x => x.Id.Equals(taskId));
        }

        public async System.Threading.Tasks.Task UpdateAsync(Domain.Tasking.Task task)
        {
            _workflowsDbContext.Tasks.Update(task);
            await _workflowsDbContext.SaveEntitiesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(Guid guid)
        {
            var task = _workflowsDbContext.Tasks.FirstOrDefault(x => x.Id.Equals(guid));

            if (task is null)
                return;

            _workflowsDbContext.Tasks.Remove(task);
            await _workflowsDbContext.SaveEntitiesAsync();
        }
    }
}