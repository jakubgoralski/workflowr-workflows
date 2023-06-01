using MediatR;

namespace WorkflowR.Workflows.Domain.Tasking
{
    public record StatusChangedDomainEvent : INotification
    {
        public string Message { get; }
        public string SentToEmailAddress { get; }

        public StatusChangedDomainEvent(string message, string sentToEmailAddress)
        {
            Message = message;
            SentToEmailAddress = sentToEmailAddress;
        }
    }
}