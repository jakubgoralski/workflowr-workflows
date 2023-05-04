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

        public async Task<bool> AddTaskAsync(
               string name,
               string description,
               Guid taskOwnerId,
               DateTime shouldBeCompletedBefore,
               bool informManagerAboutProgress,
               bool informUserWhenPreviousTaskIsCompleted)
        {
            Domain.Tasking.Task task = new Domain.Tasking.Task(
                Guid.NewGuid(),
                name,
                description,
                Status.New,
                taskOwnerId,
                shouldBeCompletedBefore,
                informManagerAboutProgress,
                informUserWhenPreviousTaskIsCompleted);
            await _taskRepository.CreateAsync(task);

            return true;
        }

        // TODO: Implement Update

        public async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            Domain.Tasking.Task task = _taskRepository.ReadAsync(taskId);

            if (task is null)
                throw new TaskDoesNotExistException(taskId);

            await _taskRepository.DeleteAsync(taskId);

            return true;
        }
    }
}