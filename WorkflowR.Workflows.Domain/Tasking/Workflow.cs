using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    internal class Workflow : IAggregate
    {
        public AggregateRoot<Task> AggregateRoot { get; }

        private LinkedList<Task> Tasks = new();
    }
}
