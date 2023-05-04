using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkflowR.Workflows.Domain.Tasking;

namespace WorkflowR.Workflows.Infrastructure.EF.Configs
{
    internal class WriteConfiguration
        : IEntityTypeConfiguration<Domain.Tasking.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Tasking.Task> builder)
        {
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
        builder.Property(typeof(bool), "InformUserWhenPreviousTaskIsCompleted")
            .HasColumnName("InformUserWhenPreviousTaskIsCompleted");

            builder.ToTable("task");
        }
    }
}