using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Infrastructure.EF.ReadModels
{
    public class TaskStatusReadModel
    {
        public Status Value { get; set; }
        public DateTime SetOn { get; set; }
    }
}
