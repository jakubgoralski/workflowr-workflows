using WorkflowR.Workflows.Application.Exceptions;
using WorkflowR.Workflows.Domain.Tasking;
using WorkflowR.Workflows.Infrastructure.EF.ReadModels;
using WorkflowR.Workflows.Infrastructure.EF.Repositories.Interfaces;

namespace WorkflowR.Workflows.Infrastructure.Tasking
{
    public class TaskMutations
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskReadRepository _taskReadRepository;

        public TaskMutations(
            ITaskRepository taskRepository,
            ITaskReadRepository taskReadRepository)
        {
            _taskRepository = taskRepository;
            _taskReadRepository = taskReadRepository;
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

        public bool UpdateStatus(Guid taskId, int newStatus)
        {
            TaskReadModel task = _taskReadRepository.ReadAsync(taskId);

            Domain.Tasking.Task taskDomain = new Domain.Tasking.Task(
                task.Id,
                task.TaskName,
                task.TaskDescription,
                (Status)task.TaskStatus,
                task.TaskOwnerId,
                task.ShouldBeCompletedBefore,
                task.InformManagerAboutProgress,
                task.InformUserWhenPreviousTaskIsCompleted);

            taskDomain.ChangeStatus((Status)newStatus);

            _taskRepository.UpdateAsync(taskDomain);

            return true;
        }

        public async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            bool doesTaskExist = await _taskRepository.ExistsAsync(taskId);

            if (!doesTaskExist)
                throw new TaskDoesNotExistException(taskId);

            await _taskRepository.DeleteAsync(taskId);

            return true;
        }
    }
}