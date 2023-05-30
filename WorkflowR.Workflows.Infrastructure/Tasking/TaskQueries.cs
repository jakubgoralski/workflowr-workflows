using WorkflowR.Workflows.Infrastructure.EF.ReadModels;
using WorkflowR.Workflows.Infrastructure.Repositories.Interfaces;

namespace WorkflowR.Workflows.Infrastructure.Tasking
{
    public class TaskQueries
    {
        private readonly ITaskReadRepository _taskRepository;

        public TaskQueries(ITaskReadRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TaskReadModel> GetAllTasks()
        {
            return _taskRepository.ReadAsync();
        }

        public TaskReadModel GetTask(Guid taskId)
        {
            return _taskRepository.ReadAsync(taskId);
        }
    }
}