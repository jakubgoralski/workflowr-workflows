using RabbitMQ.Client;
using WorkflowR.Workflows.Application.Messaging.Interfaces;
using WorkflowR.Workflows.Infrastructure.RabbitMq.Interfaces;

namespace WorkflowR.Workflows.Infrastructure.RabbitMq
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IModel _channel;

        public MessageProducer(IChannelFactory channelFactory)
        {
            _channel = channelFactory.Create();
        }

        public void Publish(string message)
        {
            byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(message);
            _channel.ExchangeDeclare("jgexchange", "topic", false, false);
            _channel.BasicPublish("jgexchange", "jgroutingkey", true, _channel.CreateBasicProperties(), messageBodyBytes);
        }
    }
}