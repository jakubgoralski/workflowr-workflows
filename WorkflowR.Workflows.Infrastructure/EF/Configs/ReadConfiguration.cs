using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkflowR.Workflows.Infrastructure.EF.ReadModels;

namespace WorkflowR.Workflows.Infrastructure.EF.Configs
{
    internal class ReadConfiguration
        : IEntityTypeConfiguration<WorkflowReadModel>,
        IEntityTypeConfiguration<TaskReadModel>
    {
        public void Configure(EntityTypeBuilder<WorkflowReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasMany(x => x.Tasks)
                .WithOne(y => y.Workflow);
            builder.ToTable("workflow");
        }

        public void Configure(EntityTypeBuilder<TaskReadModel> builder)
        {
            builder.ToTable("task");
        }
    }
}
