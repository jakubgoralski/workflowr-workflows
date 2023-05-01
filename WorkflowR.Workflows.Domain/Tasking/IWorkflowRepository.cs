namespace WorkflowR.Workflows.Domain.Tasking
{
    public interface IWorkflowRepository
    {
        void Create(Workflow workflow);
        void Update(Workflow workflow);
        Workflow Read(Guid guid);
        void Delete(Guid guid);
    }
}
