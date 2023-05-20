using RabbitMQ.Client;

namespace WorkflowR.Workflows.Infrastructure.RabbitMq.Interfaces
{
    public interface IMessageBrokerModelProvider
    {
        IModel Get();
    }
}