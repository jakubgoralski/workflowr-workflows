using WorkflowR.Workflows.Domain.Managing;
using WorkflowR.Workflows.Domain.Tasking.Repositories;

namespace WorkflowR.Workflows.Domain.Notifying
{
    public class NotifyOwnerOfNextTaskPolicy : INotificationPolicy
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITaskRepository _taskRepository;

        public NotifyOwnerOfNextTaskPolicy(
            IEmployeeRepository employeeRepository,
            ITaskRepository taskRepository)
        {
            _employeeRepository = employeeRepository;
            _taskRepository = taskRepository;
        }

        public bool IsApplicable(PolicyData data)
            => data.informUserOfNextTaskWhenThisIsCompleted && data.taskStatus is Tasking.Status.Completed;

        public async System.Threading.Tasks.Task<string> GetEmailAsync(Guid employeeId, Guid taskId)
        {
            Domain.Tasking.Task nextTask = await _taskRepository.GetAsync(taskId);
            nextTask.InformAboutCompletenessOfPreviousTaskAsync();

            return "";
        }
    }
}
