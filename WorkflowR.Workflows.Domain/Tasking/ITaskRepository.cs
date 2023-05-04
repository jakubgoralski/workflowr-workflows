namespace WorkflowR.Workflows.Domain.Tasking
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task CreateAsync(Task task);
        Task ReadAsync(Guid guid);
        System.Threading.Tasks.Task UpdateAsync(Task task);
        System.Threading.Tasks.Task DeleteAsync(Guid guid);
    }
}
