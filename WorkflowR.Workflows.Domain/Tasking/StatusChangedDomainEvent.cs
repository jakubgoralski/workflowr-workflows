using MediatR;

namespace WorkflowR.Workflows.Domain.Tasking
{
    public record StatusChangedDomainEvent : INotification
    {
        public Status From { get; }
        public Status To { get; }
        public Guid TaskId { get; }
        public Guid TaskOwnerId { get; }
        public string TaskName { get; }
        public bool InformManagerAboutProgress { get; }
        public bool InformUserOfNextTaskWhenThisIsCompleted { get; }
        public Guid NextTaskId { get; }

        public StatusChangedDomainEvent(Status from, Status to, Guid taskId, Guid taskOwnerId, string taskName, bool informManagerAboutProgress, bool informUserOfNextTaskWhenThisIsCompleted, Guid nextTaskId)
        {
            From = from;
            To = to;
            TaskId = taskId;
            TaskOwnerId = taskOwnerId;
            TaskName = taskName;
            InformManagerAboutProgress = informManagerAboutProgress;
            InformUserOfNextTaskWhenThisIsCompleted = informUserOfNextTaskWhenThisIsCompleted;
            NextTaskId = nextTaskId;
        }
    }
}