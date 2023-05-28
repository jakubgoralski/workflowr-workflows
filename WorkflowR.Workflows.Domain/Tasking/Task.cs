using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    public class Task : Entity
    {
        public Guid Id { get; set; }
        private string TaskName { get; set; } = String.Empty;
        private string TaskDescription { get; set; } = String.Empty;
        private Status TaskStatus { get; set; } = Status.None;
        private Guid TaskOwnerId { get; set; }
        private DateTime ShouldBeCompletedBefore { get; set; }
        private bool InformManagerAboutProgress { get; set; }
        private bool InformUserWhenPreviousTaskIsCompleted { get; set; }

        public Task()
        {
            
        }

        public Task(Guid taskId, string taskName)
        {
            Id = taskId;
            TaskName = taskName;
        }

        public Task(
            Guid taskId,
            string taskName,
            string taskDescription,
            Status taskStatus,
            Guid taskOwnerId,
            DateTime shouldBeCompletedBefore,
            bool informManagerAboutProgress,
            bool informUserWhenPreviousTaskIsCompleted)
        {
            Id = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskStatus = taskStatus;
            TaskOwnerId = taskOwnerId;
            ShouldBeCompletedBefore = shouldBeCompletedBefore;
            InformManagerAboutProgress = informManagerAboutProgress;
            InformUserWhenPreviousTaskIsCompleted = informUserWhenPreviousTaskIsCompleted;
        }

        public void ChangeStatus(Status status, string emailTo)
        {
            Status oldTaskStatus = TaskStatus;
            TaskStatus = status;

            RaiseDomainEvent(new StatusChangedDomainEvent(oldTaskStatus, TaskStatus, Id, TaskName, emailTo));
        }
    }
}