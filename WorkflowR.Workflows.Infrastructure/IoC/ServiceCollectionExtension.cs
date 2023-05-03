using Microsoft.EntityFrameworkCore;
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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
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
            string? connectionStringOption = configuration.GetSection(nameof(ConnectionStringOption)).Value;
            services.AddDbContext<WorkflowsDbContext>(x => 
            {
                x.UseSqlServer(connectionStringOption);
            });
            services.AddTransient<ITaskRepository, TaskRepository>();

            // Entity Framework - run migration
            //using (var scope = services.BuildServiceProvider().CreateScope())
            //{
            //    var db = scope.ServiceProvider.GetRequiredService<WorkflowsDbContext>();
            //    db.Database.Migrate();
            //}

            return services;
        }
    }
}
