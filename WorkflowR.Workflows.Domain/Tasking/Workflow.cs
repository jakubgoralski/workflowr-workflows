using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    internal class Workflow : IAggregate
    {
        public AggregateRoot<Task> aggregateRoot { get; private set; }

        private TaskStatus WorkflowStatus = new TaskStatus(Status.None);
        private List<Task> tasks = new List<Task>();
    }
}
