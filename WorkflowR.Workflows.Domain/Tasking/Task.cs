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
        private bool InformUserOfNextTaskWhenThisIsCompleted { get; set; }
        private Guid NextTaskId { get; set; }
        private Guid WorkflowId { get; set; }

        public Task()
        {

        }

        public Task(
            Guid taskId,
            string taskName,
            string taskDescription,
            Status taskStatus,
            Guid taskOwnerId,
            DateTime shouldBeCompletedBefore,
            bool informManagerAboutProgress,
            bool informUserOfNextTaskWhenThisIsCompleted,
            Guid nextTaskId,
            Guid workflowId)
        {
            Id = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskStatus = taskStatus;
            TaskOwnerId = taskOwnerId;
            ShouldBeCompletedBefore = shouldBeCompletedBefore;
            InformManagerAboutProgress = informManagerAboutProgress;
            InformUserOfNextTaskWhenThisIsCompleted = informUserOfNextTaskWhenThisIsCompleted;
            NextTaskId = nextTaskId;
            WorkflowId = workflowId;
        }

        public void ChangeStatus(Status status)
        {
            Status oldTaskStatus = TaskStatus;
            TaskStatus = status;

            RaiseDomainEvent(new StatusChangedDomainEvent(oldTaskStatus, TaskStatus, Id, TaskOwnerId, TaskName, InformManagerAboutProgress, InformUserOfNextTaskWhenThisIsCompleted, NextTaskId));
        }

        public Guid InformThatPreviousTaskIsCompleted()
        {
            return TaskOwnerId;
        }
    }
}