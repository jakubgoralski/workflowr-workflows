using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    public class Workflow : IAggregate
    {
        public AggregateRoot<Task> AggregateRoot { get; }

        private LinkedList<Task> Tasks = new();
    }
}
