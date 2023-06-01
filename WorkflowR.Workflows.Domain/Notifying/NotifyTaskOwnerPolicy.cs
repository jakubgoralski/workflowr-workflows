using WorkflowR.Workflows.Domain.Managing;

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

        public async System.Threading.Tasks.Task<string> GetEmailAsync(Guid employeeId, Guid taskId)
            => await _employeeRepository.GetEmailOfEmployeeAsync(employeeId);
    }
}
