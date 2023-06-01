namespace WorkflowR.Workflows.Infrastructure.EF.ReadModels
{
    public class WorkflowReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public LinkedList<TaskReadModel> Tasks { get; set; } = new();

        public Guid OwnerId { get; set; }

        public int WorkflowStatus { get; set; }

        public Guid FirstTaskInChain { get; set; }
    }
}