namespace WorkflowR.Workflows.Application.Messaging.Interfaces
{
    public interface IMessageProducer
    {
        void Publish(EmailObject message);
    }
}