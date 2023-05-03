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

        public void Create(Domain.Tasking.Task task)
        {
            _workflowsDbContext.Tasks.Add(task);
        }

        public void Delete(Guid guid)
        {
            var task = _workflowsDbContext.Tasks.FirstOrDefault(x => x.TaskId.Equals(guid));
            
            _workflowsDbContext.Tasks.Remove(task);
        }

        public Domain.Tasking.Task Read(Guid guid)
        {
            return _workflowsDbContext.Tasks.FirstOrDefault(x => x.TaskId.Equals(guid));
        }

        public void Update(Domain.Tasking.Task task)
        {
            _workflowsDbContext.Tasks.Update(task);
        }
    }
}
