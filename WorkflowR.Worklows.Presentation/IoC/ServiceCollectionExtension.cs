using HotChocolate.Types;
using WorkflowR.Workflows.Presentation.Tasking;

namespace WorkflowR.Worklows.Presentation.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
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

            return services;
        }
    }
}
