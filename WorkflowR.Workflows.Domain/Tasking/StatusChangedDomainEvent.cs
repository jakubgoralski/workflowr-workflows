﻿using MediatR;

namespace WorkflowR.Workflows.Domain.Tasking
{
    public record StatusChangedDomainEvent : INotification
    {
        public Status? From { get; }
        public Status? To { get; }
        public Guid TaskId { get; }
        public string TaskName { get; }
        public string SentToEmailAddress { get; }

        public StatusChangedDomainEvent(Status from, Status to, Guid taskId, string taskName, string sentToEmailAddress)
        {
            From = from;
            To = to;
            TaskId = taskId;
            TaskName = taskName;
            SentToEmailAddress = sentToEmailAddress;
        }
    }
}