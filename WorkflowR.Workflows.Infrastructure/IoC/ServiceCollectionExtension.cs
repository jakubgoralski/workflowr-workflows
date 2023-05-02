using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkflowR.Workflows.Application.Tasking;
using WorkflowR.Workflows.Domain.Tasking;
using WorkflowR.Workflows.Infrastructure.EF;
using WorkflowR.Workflows.Infrastructure.EF.Repositories;
using WorkflowR.Workflows.Infrastructure.Options;

namespace WorkflowR.Worklows.Presentation.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringOption>(configuration.GetSection(nameof(ConnectionStringOption)));

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // GrapqhQL
            services
                .AddGraphQLServer()
                 .ModifyOptions(options =>
                 {
                     options.DefaultBindingBehavior = BindingBehavior.Explicit;
                 })
                .AddQueryType<TaskQueries>()
                .AddMutationType<TaskMutations>();

            // Entity Framework - MSSQL
            services.AddSingleton<WorkflowsDbContext>();
            services.AddSingleton<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
