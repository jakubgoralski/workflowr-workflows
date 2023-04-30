namespace WorkflowR.Workflows.Domain.Tasking
{
    public interface ITaskRepository
    {
        void Create(Task task);
        void Update(Task task);
        Task Read(Guid guid);
        void Delete(Guid guid);
    }
}
