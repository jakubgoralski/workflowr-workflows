using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkflowR.Workflows.Infrastructure.EF.ReadModels;

namespace WorkflowR.Workflows.Infrastructure.EF.Configs
{
    internal class ReadConfiguration
        : IEntityTypeConfiguration<TaskReadModel>
    {
        public void Configure(EntityTypeBuilder<TaskReadModel> builder)
        {
            builder.ToTable("task");
        }
    }
}
