using Microsoft.Extensions.DependencyInjection;
using WorkflowR.Workflows.Application.EventHandlers;
using WorkflowR.Workflows.Domain.Notifying;

namespace WorkflowR.Worklows.Application.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Domain Policies
            services.AddScoped<INotificationPolicy, NotifyTaskOwnerPolicy>();
            services.AddScoped<INotificationPolicy, NotifyOwnerOfNextTaskPolicy>();
            services.AddScoped<INotificationPolicy, NotifyManagerPolicy>();

            // MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<StatusChangedDomainEventHandler>());

            return services;
        }
    }
}