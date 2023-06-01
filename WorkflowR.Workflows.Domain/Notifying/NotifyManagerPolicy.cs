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

        public async System.Threading.Tasks.Task<string> GetEmailAsync(Guid employeeId, Guid taskId)
            => await _employeeRepository.GetEmailOfManagerAsync(employeeId);
    }
}
