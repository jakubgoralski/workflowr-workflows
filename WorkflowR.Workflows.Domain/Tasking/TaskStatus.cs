using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    public record TaskStatus : IValueObject
    {
        public Status Value { get; }
        public DateTime SetOn { get; }

        public TaskStatus(Status value)
        {
            Value = value;
            SetOn = DateTime.UtcNow;
        }
    }
}
