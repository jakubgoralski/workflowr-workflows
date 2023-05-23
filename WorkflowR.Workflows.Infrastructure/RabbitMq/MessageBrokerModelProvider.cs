using RabbitMQ.Client;
using WorkflowR.Workflows.Infrastructure.RabbitMq.Interfaces;

namespace WorkflowR.Workflows.Infrastructure.RabbitMq
{
    public class MessageBrokerModelProvider : IMessageBrokerModelProvider
    {
        private IConnection _connection { get; }

        public MessageBrokerModelProvider(IConnectionFactory connectionFactory)
        {
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";
            connectionFactory.VirtualHost = "rabbitmq";

            connectionFactory.Uri = new Uri("amqp://user:pass@localhost:port/vhost");

            _connection = connectionFactory.CreateConnection();
        }

        public IModel Get()
        {
            return _connection.CreateModel();
        }
    }
}