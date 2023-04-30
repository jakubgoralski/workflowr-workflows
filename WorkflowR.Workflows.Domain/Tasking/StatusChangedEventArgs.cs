using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    internal class StatusChangedEventArgs : EventArgs, IDomainEvent
    {
        public TaskStatus? From { get; }
        public Task Task { get; }

        public StatusChangedEventArgs(TaskStatus from, Task task)
        {
            From = from;
            Task = task;
        }
    }
}
