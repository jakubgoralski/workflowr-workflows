using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    public class StatusChangedEventArgs : EventArgs, IDomainEvent
    {
        public Status? From { get; }
        public Task Task { get; }

        public StatusChangedEventArgs(Status from, Task task)
        {
            From = from;
            Task = task;
        }
    }
}
