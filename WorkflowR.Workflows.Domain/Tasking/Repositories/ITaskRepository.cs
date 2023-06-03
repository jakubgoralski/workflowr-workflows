namespace WorkflowR.Workflows.Domain.Tasking.Repositories
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task CreateAsync(Task task);
        Task<bool> ExistsAsync(Guid taskId);
        Task<Domain.Tasking.Task> GetAsync(Guid taskId);
        System.Threading.Tasks.Task UpdateAsync(Task task);
        System.Threading.Tasks.Task DeleteAsync(Guid guid);
    }
}
