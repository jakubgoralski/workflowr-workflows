using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Application.Dto
{
    public class TaskDto
    {
        public Guid TaskId { get; set; } = Guid.NewGuid();
        public string TaskName { get; set; } = String.Empty;
        public string TaskDescription { get; set; } = String.Empty;
        public TaskStatusDto TaskStatus { get; set; } = new TaskStatusDto();
        public Guid TaskOwnerId { get; set; } = Guid.NewGuid();
        public DateTime ShouldBeCompletedBefore { get; set; } = DateTime.UtcNow;

        public TaskDto()
        {

        }

        public TaskDto(Guid taskId, string taskName)
        {
            TaskId = taskId;
            TaskName = taskName;
        }

        public TaskDto(
            Guid taskId,
            string taskName,
            string taskDescription,
            Domain.Tasking.TaskStatus taskStatus,
            Guid taskOwnerId,
            DateTime shouldBeCompletedBefore)
        {
            TaskId = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskStatus = new TaskStatusDto();
            TaskOwnerId = taskOwnerId;
            ShouldBeCompletedBefore = shouldBeCompletedBefore;
        }
    }
}
