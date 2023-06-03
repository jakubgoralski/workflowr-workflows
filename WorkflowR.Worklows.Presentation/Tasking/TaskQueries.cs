using WorkflowR.Workflows.Infrastructure.EF.ReadModels;
using WorkflowR.Workflows.Infrastructure.Repositories.Interfaces;

namespace WorkflowR.Workflows.Presentation.Tasking
{
    public class TaskQueries
    {
        private readonly ITaskReadRepository _taskRepository;
        private readonly IWorkflowReadRepository _workflowRepository;

        public TaskQueries(ITaskReadRepository taskRepository, IWorkflowReadRepository workflowRepository)
        {
            _taskRepository = taskRepository;
            _workflowRepository = workflowRepository;
        }

        public List<TaskReadModel> GetAllTasks()
        {
            return _taskRepository.ReadAsync();
        }

        public TaskReadModel GetTask(Guid taskId)
        {
            return _taskRepository.ReadAsync(taskId);
        }

        public List<WorkflowReadModel> GetAllWorkflows()
        {
            return _workflowRepository.ReadAsync();
        }

        public WorkflowReadModel GetWorkflow(Guid workflowId)
        {
            return _workflowRepository.ReadAsync(workflowId);
        }
    }
}