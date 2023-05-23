using RabbitMQ.Client;

namespace WorkflowR.Workflows.Infrastructure.RabbitMq.Interfaces;

public interface IChannelFactory
{
    IModel Create();
}