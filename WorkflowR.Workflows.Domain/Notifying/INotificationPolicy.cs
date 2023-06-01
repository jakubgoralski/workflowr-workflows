namespace WorkflowR.Workflows.Domain.Notifying
{
    public interface INotificationPolicy
    {
        bool IsApplicable(PolicyData data);
        System.Threading.Tasks.Task<string> GetEmailAsync(Guid employeeId, Guid taskId);
    }
}