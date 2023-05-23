using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using WorkflowR.Workflows.Application.EventHandlers;
using WorkflowR.Workflows.Application.Messaging.Interfaces;
using WorkflowR.Workflows.Domain.Tasking;
using WorkflowR.Workflows.Infrastructure.EF.Contexts;
using WorkflowR.Workflows.Infrastructure.EF.Repositories;
using WorkflowR.Workflows.Infrastructure.EF.Repositories.Interfaces;
using WorkflowR.Workflows.Infrastructure.Options;
using WorkflowR.Workflows.Infrastructure.RabbitMq;
using WorkflowR.Workflows.Infrastructure.RabbitMq.Interfaces;
using WorkflowR.Workflows.Infrastructure.Tasking;

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
            services.AddDbContext<WorkflowsReadDbContext>(x =>
            {
                x.UseSqlServer(connectionStringOption);
            });
            services.AddDbContext<WorkflowsWriteDbContext>(x => 
            {
                x.UseSqlServer(connectionStringOption);
            });
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskReadRepository, TaskReadRepository>();

            // MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<StatusChangedDomainEventHandler>());

            // RabbitMq
            var factory = new ConnectionFactory { HostName = "rabbitmq" }; // localhost for self run / rabbitmq for container
            var connection = factory.CreateConnection();
            services.AddSingleton(connection);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<ChannelAccessor>();
            services.AddSingleton<IChannelFactory, ChannelFactory>();
            services.AddSingleton<IMessageProducer, MessageProducer>();

            // Entity Framework - run migration
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var db1 = scope.ServiceProvider.GetRequiredService<WorkflowsReadDbContext>();
                db1.Database.Migrate();
                var db2 = scope.ServiceProvider.GetRequiredService<WorkflowsWriteDbContext>();
                db2.Database.Migrate();
            }

            return services;
        }
    }
}
