namespace WorkflowR.Workflows.Domain.Notifying
{
    public interface IPoliciesProvider
    {
        IEnumerable<INotificationPolicy> Get();
    }

    public class PoliciesProvider : IPoliciesProvider
    {
        private readonly IEnumerable<INotificationPolicy> _policies;

        public PoliciesProvider(IEnumerable<INotificationPolicy> policies)
        {
            _policies = policies;
        }

        public IEnumerable<INotificationPolicy> Get()
        =>  _policies;
    }
}
