using WorkflowR.Workflows.Domain.Tasking;
using WorkflowR.Workflows.Infrastructure.EF.ReadModels;

namespace WorkflowR.Workflows.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static LinkedList<Domain.Tasking.Task> ToDomainTaskList(this LinkedList<TaskReadModel> tasksReadModelList)
        {
            LinkedList<Domain.Tasking.Task> taskList = new LinkedList<Domain.Tasking.Task>();
            foreach (var task in tasksReadModelList)
                taskList.AddLast(
                new Domain.Tasking.Task(
                    task.Id,
                    task.TaskName,
                    task.TaskDescription,
                    (Status)task.TaskStatus,
                    task.TaskOwnerId,
                    task.ShouldBeCompletedBefore,
                    task.InformManagerAboutProgress,
                    task.InformUserOfNextTaskWhenThisIsCompleted,
                    task.NextTaskId,
                    task.Workflow.Id));

            return taskList;
        }
    }
}