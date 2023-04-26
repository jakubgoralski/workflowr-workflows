using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    internal class StatusChangedEventArgs : EventArgs, IDomainEvent
    {
        public StatusChangedEventArgs(TaskStatus from, TaskStatus to, Guid taskId)
        {
            From = from;
            To = to;
            TaskId = taskId;
        }

        public TaskStatus? From { get; set; }
        public TaskStatus? To { get; set; }
        public Guid TaskId { get; set; }
    }
}
