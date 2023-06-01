using WorkflowR.Workflows.Domain.Abstraction;
using WorkflowR.Workflows.Domain.Notifying;

namespace WorkflowR.Workflows.Domain.Tasking
{
    public class Task : Entity
    {
        public Guid Id { get; set; }
        private string TaskName { get; set; } = String.Empty;
        private string TaskDescription { get; set; } = String.Empty;
        private Status TaskStatus { get; set; } = Status.None;
        private Guid TaskOwnerId { get; set; }
        private DateTime ShouldBeCompletedBefore { get; set; }
        private bool InformManagerAboutProgress { get; set; }
        private bool InformUserOfNextTaskWhenThisIsCompleted { get; set; }
        private Guid NextTaskId { get; set; }
        private Guid WorkflowId { get; set; }

        private readonly List<INotificationPolicy> _policies;

        public Task()
        {

        }

        public Task(
            Guid taskId,
            string taskName,
            string taskDescription,
            Status taskStatus,
            Guid taskOwnerId,
            DateTime shouldBeCompletedBefore,
            bool informManagerAboutProgress,
            bool informUserOfNextTaskWhenThisIsCompleted,
            Guid nextTaskId,
            Guid workflowId)
        {
            Id = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskStatus = taskStatus;
            TaskOwnerId = taskOwnerId;
            ShouldBeCompletedBefore = shouldBeCompletedBefore;
            InformManagerAboutProgress = informManagerAboutProgress;
            InformUserOfNextTaskWhenThisIsCompleted = informUserOfNextTaskWhenThisIsCompleted;
            NextTaskId = nextTaskId;
            WorkflowId = workflowId;

            _policies.Add(new NotifyManagerPolicy());
            _policies.Add(new NotifyOwnerOfNextTaskPolicy());
            _policies.Add(new NotifyTaskOwnerPolicy());
        }

        public async System.Threading.Tasks.Task ChangeStatusAsync(Status status)
        {
            Status oldTaskStatus = TaskStatus;
            TaskStatus = status;

            PolicyData data = new PolicyData(InformManagerAboutProgress, InformUserOfNextTaskWhenThisIsCompleted, false, TaskStatus);
            IEnumerable<INotificationPolicy> applicablePolicies = _policies.Where(x => x.IsApplicable(data));

            foreach(INotificationPolicy policy in applicablePolicies)
            {
                string email = await policy.GetEmailAsync(TaskOwnerId, NextTaskId);
                if (!String.IsNullOrWhiteSpace(email))
                {
                    string message = $"Task `{TaskName}` (id: {Id}) status has been changed from `{oldTaskStatus}` to `{status}`.";
                    RaiseDomainEvent(new StatusChangedDomainEvent(message, email));
                }
            }
        }

        public async System.Threading.Tasks.Task InformAboutCompletenessOfPreviousTaskAsync()
        {

            PolicyData data = new PolicyData(false, false, true, TaskStatus);
            IEnumerable<INotificationPolicy> applicablePolicies = _policies.Where(x => x.IsApplicable(data));

            foreach (INotificationPolicy policy in applicablePolicies)
            {
                string email = await policy.GetEmailAsync(TaskOwnerId, NextTaskId);
                if (!String.IsNullOrWhiteSpace(email))
                {
                    string message = $"Task `{TaskName}` (id: {Id}) is waiting as preceding task has been completed`.";
                    RaiseDomainEvent(new StatusChangedDomainEvent(message, email));
                }
            }
        }
    }
}