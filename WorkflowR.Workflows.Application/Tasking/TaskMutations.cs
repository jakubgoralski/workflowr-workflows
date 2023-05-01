using WorkflowR.Workflows.Application.Exceptions;
using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Application.Tasking
{
    public class TaskMutations
    {
        private readonly ITaskRepository _taskRepository;

        public TaskMutations(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<bool> AddTaskAsync(string name)
        {
            Domain.Tasking.Task task = new Domain.Tasking.Task(Guid.NewGuid(), name);
            _taskRepository.Create(task);

            return System.Threading.Tasks.Task.FromResult(true);
        }

        // TODO: Implement Update

        public Task<bool> DeleteTaskAsync(Guid taskId)
        {
            Domain.Tasking.Task task = _taskRepository.Read(taskId);

            if (task is null)
                throw new TaskDoesNotExistException(taskId);

            _taskRepository.Delete(taskId);

            return System.Threading.Tasks.Task.FromResult(true);
        }
    }
}