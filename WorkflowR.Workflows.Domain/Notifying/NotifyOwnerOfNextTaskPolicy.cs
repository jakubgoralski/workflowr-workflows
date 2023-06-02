using WorkflowR.Workflows.Domain.Managing;
using WorkflowR.Workflows.Domain.Tasking;
using WorkflowR.Workflows.Domain.Tasking.Repositories;

namespace WorkflowR.Workflows.Domain.Notifying
{
    public class NotifyOwnerOfNextTaskPolicy : INotificationPolicy
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public NotifyOwnerOfNextTaskPolicy(
            ITaskRepository taskRepository, IEmployeeRepository employeeRepository)
        {
            _taskRepository = taskRepository;
            _employeeRepository = employeeRepository;
        }

        public bool IsApplicable(PolicyData data)
            => data.informUserOfNextTaskWhenThisIsCompleted && data.taskStatus is Tasking.Status.Completed;

        public async System.Threading.Tasks.Task<(string address, string message)> GetEmailAsync(StatusChangedDomainEvent notification)
        {
            Domain.Tasking.Task nextTask = await _taskRepository.GetAsync(notification.NextTaskId);
            Guid nextTaskOwnerId = nextTask.InformThatPreviousTaskIsCompleted();
            string address = await _employeeRepository.GetEmailOfEmployeeAsync(notification.TaskOwnerId);
            string message = $"Task `{notification.TaskName}` (id: {notification.TaskId}) is waiting as preceding task has been completed`.";

            return (address, message);
        }
    }
}
