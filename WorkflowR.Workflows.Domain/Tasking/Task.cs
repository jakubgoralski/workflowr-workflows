﻿using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    public class Task : IEntity
    {
        public Guid Id { get; set; }
        private string TaskName { get; set; } = String.Empty;
        private string TaskDescription { get; set; } = String.Empty;
        private Status TaskStatus { get; set; } = Status.None;
        private Guid TaskOwnerId { get; set; }
        private DateTime ShouldBeCompletedBefore { get; set; }
        private bool InformManagerAboutProgress { get; set; }
        private bool InformUserWhenPreviousTaskIsCompleted { get; set; }

        private event EventHandler<StatusChangedEventArgs> RaiseStatusChangedEvent;

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

        public void SubscribeToChangeStatusEvent(EventHandler<StatusChangedEventArgs> eventHandler)
        {
            RaiseStatusChangedEvent += eventHandler;
        }

        public void ChangeStatus(Status status)
        {
            Status oldTaskStatus = TaskStatus;
            TaskStatus = status;

            RaiseStatusChangedEvent(this, new StatusChangedEventArgs(oldTaskStatus, this));
        }
    }
}