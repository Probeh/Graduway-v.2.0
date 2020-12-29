using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces;

namespace Server.Extensions
{
    public static partial class Extensions
    {
        // ======================================= //
        //     Configuring Scoped Dependencies
        // ======================================= //
        public static IServiceCollection SetDependencies(this IServiceCollection services) =>
            services
            .AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<ITaskRepository, TaskRepository>();
    }
}