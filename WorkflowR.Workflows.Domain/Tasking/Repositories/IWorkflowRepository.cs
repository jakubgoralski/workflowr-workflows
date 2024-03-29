﻿namespace WorkflowR.Workflows.Domain.Tasking.Repositories
{
    public interface IWorkflowRepository
    {
        System.Threading.Tasks.Task CreateAsync(Workflow workflow);
        System.Threading.Tasks.Task UpdateAsync(Workflow workflow);
        Task<Workflow> ReadAsync(Guid guid);
        System.Threading.Tasks.Task DeleteAsync(Guid guid);
    }
}