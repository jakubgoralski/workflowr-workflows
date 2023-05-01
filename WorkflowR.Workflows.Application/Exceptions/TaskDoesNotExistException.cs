namespace WorkflowR.Workflows.Application.Exceptions
{
    public class TaskDoesNotExistException : Exception
    {
        public TaskDoesNotExistException(Guid taskId)
            : base($"Task with Id `{taskId}` does not exists.")
        {
            
        }
    }
}
