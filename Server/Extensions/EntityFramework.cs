using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Context;

namespace Server.Extensions
{
    public static partial class Extensions
    {
        // ======================================= //
        //     Configuring EntityFrameworkCore
        // ======================================= //
        public static IServiceCollection SetEntityFramework(this IServiceCollection services, IConfiguration config) =>
            services.AddDbContext<DataContext>(x => x.UseSqlite(config.GetConnectionString("Application"), c => c.MigrationsAssembly("Server")));
    }
}