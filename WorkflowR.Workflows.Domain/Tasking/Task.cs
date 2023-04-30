using System.Data;
using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    internal partial class Task : IEntity
    {
        private Guid TaskId { get; set; }
        private string TaskName { get; set; } = String.Empty;
        private string TaskDescription { get; set; } = String.Empty;
        private TaskStatus TaskStatus { get; set; } = new TaskStatus(Status.None);
        private Guid TaskOwnerId { get; set; }
        private DateTime ShouldBeCompletedBefore { get; set; }

        private event EventHandler<StatusChangedEventArgs> RaiseStatusChangedEvent;

        public Task()
        {
            
        }

        public Task(Guid taskId, string taskName, string taskDescription, TaskStatus taskStatus, Guid taskOwnerId, DateTime shouldBeCompletedBefore)
        {
            TaskId = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskStatus = taskStatus;
            TaskOwnerId = taskOwnerId;
            ShouldBeCompletedBefore = shouldBeCompletedBefore;
        }

        public void SubscribeToChangeStatusEvent(EventHandler<StatusChangedEventArgs> eventHandler)
        {
            RaiseStatusChangedEvent += eventHandler;
        }

        public void ChangeStatus(TaskStatus status)
        {
            TaskStatus oldTaskStatus = TaskStatus;
            TaskStatus = status;

            RaiseStatusChangedEvent(this, new StatusChangedEventArgs(oldTaskStatus, this));
        }
    }
}