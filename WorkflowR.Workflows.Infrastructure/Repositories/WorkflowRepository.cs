using Microsoft.EntityFrameworkCore;
using WorkflowR.Workflows.Domain.Tasking;
using WorkflowR.Workflows.Infrastructure.EF.Contexts;

namespace WorkflowR.Workflows.Infrastructure.Repositories
{
    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly WorkflowsWriteDbContext _workflowsDbContext;

        public WorkflowRepository(
            WorkflowsWriteDbContext workflowsDbContext)
        {
            _workflowsDbContext = workflowsDbContext;
        }

        public async System.Threading.Tasks.Task CreateAsync(Workflow workflow)
        {
            await _workflowsDbContext.Workflows.AddAsync(workflow);
            await _workflowsDbContext.SaveEntitiesAsync();
        }

        public async System.Threading.Tasks.Task<Workflow> ReadAsync(Guid guid)
        {
            return await _workflowsDbContext.Workflows.FirstOrDefaultAsync(x => x.Id.Equals(guid));
        }

        public async System.Threading.Tasks.Task UpdateAsync(Workflow workflow)
        {
            _workflowsDbContext.Workflows.Update(workflow);
            await _workflowsDbContext.SaveEntitiesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(Guid guid)
        {
            Workflow workflow = _workflowsDbContext.Workflows.FirstOrDefault(x => x.Id.Equals(guid));

            if (workflow is null)
                return;

            _workflowsDbContext.Workflows.Remove(workflow);
            await _workflowsDbContext.SaveEntitiesAsync();
        }
    }
}