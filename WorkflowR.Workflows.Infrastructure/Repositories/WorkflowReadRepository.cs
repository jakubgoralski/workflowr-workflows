using WorkflowR.Workflows.Infrastructure.EF.Contexts;
using WorkflowR.Workflows.Infrastructure.EF.ReadModels;
using WorkflowR.Workflows.Infrastructure.Repositories.Interfaces;

namespace WorkflowR.Workflows.Infrastructure.Repositories
{
    public class WorkflowReadRepository : IWorkflowReadRepository
    {
        private readonly WorkflowsReadDbContext _workflowsReadDbContext;

        public WorkflowReadRepository(
            WorkflowsReadDbContext workflowsReadDbContext)
        {
            _workflowsReadDbContext = workflowsReadDbContext;
        }

        public List<WorkflowReadModel> ReadAsync()
        {
            return _workflowsReadDbContext.Workflows.ToList();
        }

        public WorkflowReadModel ReadAsync(Guid guid)
        {
            return _workflowsReadDbContext.Workflows.First(x => x.Id.Equals(guid));
        }
    }
}