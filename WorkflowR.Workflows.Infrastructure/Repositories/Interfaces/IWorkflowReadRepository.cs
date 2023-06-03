using WorkflowR.Workflows.Infrastructure.EF.ReadModels;

namespace WorkflowR.Workflows.Infrastructure.Repositories.Interfaces
{
    public interface IWorkflowReadRepository
    {
        List<WorkflowReadModel> ReadAsync();
        WorkflowReadModel ReadAsync(Guid guid);
    }
}