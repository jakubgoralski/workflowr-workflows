using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Domain.Notifying
{
    public interface INotificationPolicy
    {
        bool IsApplicable(PolicyData data);
        System.Threading.Tasks.Task<(string address, string message)> GetEmailAsync(StatusChangedDomainEvent notification);
    }
}