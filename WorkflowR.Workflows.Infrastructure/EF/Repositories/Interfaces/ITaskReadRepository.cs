using WorkflowR.Workflows.Infrastructure.EF.ReadModels;

namespace WorkflowR.Workflows.Infrastructure.EF.Repositories.Interfaces
{
    public interface ITaskReadRepository
    {
        List<TaskReadModel> ReadAsync();
        TaskReadModel ReadAsync(Guid guid);
    }
}