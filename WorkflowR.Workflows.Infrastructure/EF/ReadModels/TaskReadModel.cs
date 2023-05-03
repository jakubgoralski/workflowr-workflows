namespace WorkflowR.Workflows.Infrastructure.EF.ReadModels
{
    public class TaskReadModel
    {
        public Guid TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public TaskReadModel? TaskStatus { get; set; }
        public Guid TaskOwnerId { get; set; }
        public DateTime ShouldBeCompletedBefore { get; set; }
        public bool InformManagerAboutProgress { get; set; }
        public bool InformUserWhenPreviousTaskIsCompleted { get; set; }
    }
}
