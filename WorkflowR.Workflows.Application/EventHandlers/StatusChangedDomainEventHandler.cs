using MediatR;
using WorkflowR.Workflows.Application.Messaging.Interfaces;
using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Application.EventHandlers
{
    public class StatusChangedDomainEventHandler : INotificationHandler<StatusChangedDomainEvent>
    {
        private readonly IMessageProducer _messageProducer;

        public StatusChangedDomainEventHandler(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        public System.Threading.Tasks.Task Handle(StatusChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            string message = $"Task `{notification.TaskName}` (id: {notification.TaskId}) status has been changed from `{notification.From}` to `{notification.To}`.";
            _messageProducer.Publish(message);

            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}