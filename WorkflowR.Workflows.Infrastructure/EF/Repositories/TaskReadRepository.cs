using WorkflowR.Workflows.Infrastructure.EF.Contexts;
using WorkflowR.Workflows.Infrastructure.EF.ReadModels;
using WorkflowR.Workflows.Infrastructure.EF.Repositories.Interfaces;

namespace WorkflowR.Workflows.Infrastructure.EF.Repositories
{
    public class TaskReadRepository : ITaskReadRepository
    {
        private readonly WorkflowsReadDbContext _workflowsReadDbContext;

        public TaskReadRepository(
            WorkflowsReadDbContext workflowsReadDbContext)
        {
            _workflowsReadDbContext = workflowsReadDbContext;
        }

        public List<TaskReadModel> ReadAsync()
        {
            return _workflowsReadDbContext.Tasks.ToList();
        }

        public TaskReadModel ReadAsync(Guid guid)
        {
            return _workflowsReadDbContext.Tasks.First(x => x.Id.Equals(guid));
        }
    }
}