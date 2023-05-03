using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkflowR.Workflows.Infrastructure.EF.ReadModels;

namespace WorkflowR.Workflows.Infrastructure.EF.Configs
{
    internal class DbConfiguration
        : IEntityTypeConfiguration<TaskReadModel>,
        IEntityTypeConfiguration<TaskStatusReadModel>
    {
        public void Configure(EntityTypeBuilder<TaskReadModel> builder)
        {
            builder.ToTable("task");
        }

        public void Configure(EntityTypeBuilder<TaskStatusReadModel> builder)
        {
            builder.ToTable("taskstatus");
        }
    }
}
