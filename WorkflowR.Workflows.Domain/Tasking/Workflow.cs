using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    public class Workflow : Entity, IAggregate
    {
        public Guid Id { get; set; } // Aggregate Root

        private string Name { get; set; }

        private LinkedList<Task> Tasks { get; set; } = new();

        private Guid OwnerId { get; set; }

        private Status WorkflowStatus { get; set; }

        private Guid FirstTaskInChain { get; set; }
    }
}