using WorkflowR.Workflows.Application.Dto;

namespace WorkflowR.Workflows.Application.Tasking
{
    public class TaskQueries
    {
        public TaskQueries()
        {
            
        }

        public TaskDto GetTask()
        {
            return new TaskDto(Guid.NewGuid(), "JG Task");
        }
    }
}