using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Infrastructure.EF.ReadModels
{
    public class TaskReadModel
    {
        public Guid Id { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public int TaskStatus { get; set; }
        public Guid TaskOwnerId { get; set; }
        public DateTime ShouldBeCompletedBefore { get; set; }
        public bool InformManagerAboutProgress { get; set; }
        public bool InformUserWhenPreviousTaskIsCompleted { get; set; }
    }
}
