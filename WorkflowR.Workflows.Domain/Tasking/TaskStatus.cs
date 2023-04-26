﻿using WorkflowR.Workflows.Domain.Abstraction;

namespace WorkflowR.Workflows.Domain.Tasking
{
    internal record TaskStatus : IValueObject
    {
        public Status Value { get; }

        public TaskStatus(Status value)
        {
            Value = value;
        }
    }
}