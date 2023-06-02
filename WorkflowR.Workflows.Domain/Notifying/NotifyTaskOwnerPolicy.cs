using WorkflowR.Workflows.Domain.Managing;
using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Domain.Notifying
{
    public class NotifyTaskOwnerPolicy : INotificationPolicy
    {
        private readonly IEmployeeRepository _employeeRepository;

        public NotifyTaskOwnerPolicy(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool IsApplicable(PolicyData data)
            => true;

        public async System.Threading.Tasks.Task<(string address, string message)> GetEmailAsync(StatusChangedDomainEvent notification)
        {
            string address = await _employeeRepository.GetEmailOfEmployeeAsync(notification.TaskOwnerId);
            string message = $"Task `{notification.TaskName}` (id: {notification.TaskId}) status has been changed from `{notification.From}` to `{notification.To}`."; ;

            return (address, message);
        }
    }
}
