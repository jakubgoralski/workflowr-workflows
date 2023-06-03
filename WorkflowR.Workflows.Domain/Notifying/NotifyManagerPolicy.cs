using WorkflowR.Workflows.Domain.Managing;
using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Domain.Notifying
{
    public class NotifyManagerPolicy : INotificationPolicy
    {
        private readonly IEmployeeRepository _employeeRepository;

        public NotifyManagerPolicy(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool IsApplicable(PolicyData data)
            => data.informManagerAboutProgress;

        public async System.Threading.Tasks.Task<(string address, string message)> GetEmailAsync(StatusChangedDomainEvent notification)
        {
            string address = await _employeeRepository.GetEmailOfManagerAsync(notification.TaskOwnerId);
            string message = $"Dear Manager of Employee being responsible for the task.\n\nTask `{notification.TaskName}` (id: {notification.TaskId}) status has been changed from `{notification.From}` to `{notification.To}`."; ;

            return (address, message);
        }
    }
}
