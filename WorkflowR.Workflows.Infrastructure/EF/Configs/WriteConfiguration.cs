using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Infrastructure.EF.Configs
{
    internal class WriteConfiguration
        : IEntityTypeConfiguration<Workflow>,
        IEntityTypeConfiguration<Domain.Tasking.Task>
    {
        public void Configure(EntityTypeBuilder<Workflow> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(typeof(string), "Name")
                .HasColumnName("Name");
            builder.HasMany(typeof(Domain.Tasking.Task), "Tasks");
            builder.Property(typeof(Guid), "OwnerId")
                .HasColumnName("OwnerId");
            builder.Property(typeof(Status), "WorkflowStatus")
                .HasColumnName("WorkflowStatus");
            builder.Property(typeof(Guid), "FirstTaskInChain")
                .HasColumnName("FirstTaskInChain");

            builder.ToTable("workflow");
        }

        public void Configure(EntityTypeBuilder<Domain.Tasking.Task> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(typeof(string), "TaskName")
                .HasColumnName("TaskName");
            builder.Property(typeof(string), "TaskDescription")
                .HasColumnName("TaskDescription");
            builder.Property(typeof(Status), "TaskStatus")
                .HasColumnName("TaskStatus");
            builder.Property(typeof(Guid), "TaskOwnerId")
                .HasColumnName("TaskOwnerId");
            builder.Property(typeof(DateTime), "ShouldBeCompletedBefore")
                .HasColumnName("ShouldBeCompletedBefore");
            builder.Property(typeof(bool), "InformManagerAboutProgress")
                .HasColumnName("InformManagerAboutProgress");
            builder.Property(typeof(bool), "InformUserOfNextTaskWhenThisIsCompleted")
                .HasColumnName("InformUserOfNextTaskWhenThisIsCompleted");
            builder.Property(typeof(Guid), "NextTaskId")
                .HasColumnName("NextTaskId");

            builder.ToTable("task");
        }
    }
}