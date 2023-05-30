using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using WorkflowR.Workflows.Application.Messaging.Interfaces;
using WorkflowR.Workflows.Infrastructure.RabbitMq.Interfaces;
using WorkflowR.Workflows.Application.Messaging;

namespace WorkflowR.Workflows.Infrastructure.RabbitMq
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IModel _channel;

        public MessageProducer(IChannelFactory channelFactory)
        {
            _channel = channelFactory.Create();
        }

        public void Publish(EmailObject emailobject)
        {
            var messageJson = JsonSerializer.Serialize(emailobject);
            byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(messageJson);
            _channel.ExchangeDeclare("jgexchange", "topic", false, false);
            _channel.BasicPublish("jgexchange", "jgroutingkey", true, _channel.CreateBasicProperties(), messageBodyBytes);
        }
    }
}