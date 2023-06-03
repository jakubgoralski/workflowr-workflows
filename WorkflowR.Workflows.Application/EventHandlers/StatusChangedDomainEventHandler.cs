using MediatR;
using WorkflowR.Workflows.Application.Messaging;
using WorkflowR.Workflows.Application.Messaging.Interfaces;
using WorkflowR.Workflows.Domain.Notifying;
using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Application.EventHandlers
{
    public class StatusChangedDomainEventHandler : INotificationHandler<StatusChangedDomainEvent>
    {
        private readonly IMessageProducer _messageProducer;
        private readonly IEnumerable<INotificationPolicy> _policies;

        public StatusChangedDomainEventHandler(
            IMessageProducer messageProducer,
            IEnumerable<INotificationPolicy> policies)
        {
            _messageProducer = messageProducer;
            _policies = policies;
        }

        public async System.Threading.Tasks.Task Handle(StatusChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            PolicyData data = new PolicyData(notification.InformManagerAboutProgress, notification.InformUserOfNextTaskWhenThisIsCompleted, notification.To);

            IEnumerable<INotificationPolicy> applicablePolicies = _policies.Where(x => x.IsApplicable(data));

            foreach (INotificationPolicy policy in applicablePolicies)
            {
                (string address, string message) email = await policy.GetEmailAsync(notification);

                if (!String.IsNullOrWhiteSpace(email.address) && !String.IsNullOrWhiteSpace(email.message))
                {
                    EmailObject emailobject = new EmailObject(email.address, email.message);
                    _messageProducer.Publish(emailobject);
                }
            }
        }
    }
}