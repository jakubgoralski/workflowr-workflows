using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Domain.Notifying
{
    public record PolicyData(bool informManagerAboutProgress, bool informUserOfNextTaskWhenThisIsCompleted, bool informOwnerOfThisTask, Status taskStatus);
}