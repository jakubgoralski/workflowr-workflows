﻿namespace WorkflowR.Workflows.Domain.Managing
{
    public interface IEmployeeRepository
    {
        Task<string> GetEmailOfEmployeeAsync(Guid employeeId);
    }
}
