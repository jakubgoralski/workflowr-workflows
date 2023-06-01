using WorkflowR.Workflows.Application.Exceptions;
using WorkflowR.Workflows.Domain.Managing;
using WorkflowR.Workflows.Domain.Tasking;
using WorkflowR.Workflows.Domain.Tasking.Repositories;
using WorkflowR.Workflows.Infrastructure.EF.ReadModels;
using WorkflowR.Workflows.Infrastructure.Repositories.Interfaces;

namespace WorkflowR.Workflows.Infrastructure.Tasking
{
    public class TaskMutations
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IWorkflowRepository _workflowRepository;
        private readonly ITaskReadRepository _taskReadRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public TaskMutations(
            ITaskRepository taskRepository,
            IWorkflowRepository workflowRepository,
            ITaskReadRepository taskReadRepository,
            IEmployeeRepository employeeRepository)
        {
            _taskRepository = taskRepository;
            _workflowRepository = workflowRepository;
            _taskReadRepository = taskReadRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> AddWorkflowAsync(
            string name,
            Guid ownerId,
            Guid firstTaskInChain)
        {
            Workflow workflow = new Workflow(
                Guid.NewGuid(),
                name,
                new LinkedList<Domain.Tasking.Task>(),
                ownerId,
                Status.New,
                firstTaskInChain);
            await _workflowRepository.CreateAsync(workflow);

            return true;
        }

        public async Task<bool> UpdateWorkflowAsync(
            string name,
            Guid ownerId,
            int status,
            Guid firstTaskInChain)
        {
            Workflow workflow = new Workflow(
                Guid.NewGuid(),
                name,
                new LinkedList<Domain.Tasking.Task>(),
                ownerId,
                (Status)status,
                firstTaskInChain);
            await _workflowRepository.UpdateAsync(workflow);

            return true;
        }

        public async Task<bool> AddTaskAsync(
               string name,
               string description,
               Guid taskOwnerId,
               DateTime shouldBeCompletedBefore,
               bool informManagerAboutProgress,
               bool informUserOfNextTaskWhenThisIsCompleted,
               Guid nextTaskId,
               Guid workflowId)
        {
            Domain.Tasking.Task task = new Domain.Tasking.Task(
                Guid.NewGuid(),
                name,
                description,
                Status.New,
                taskOwnerId,
                shouldBeCompletedBefore,
                informManagerAboutProgress,
                informUserOfNextTaskWhenThisIsCompleted,
                nextTaskId,
                workflowId);
            await _taskRepository.CreateAsync(task);

            return true;
        }

        public async System.Threading.Tasks.Task<bool> UpdateStatusAsync(Guid taskId, int newStatus)
        {
            Domain.Tasking.Task task = await _taskRepository.GetAsync(taskId);
            await task.ChangeStatusAsync((Status)newStatus);

            await _taskRepository.UpdateAsync(task);
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