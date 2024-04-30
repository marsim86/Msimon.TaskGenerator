using Microsoft.Extensions.Configuration;
using Msimon.TaskGenerator.Infrastructure.Contracts;
using Msimon.TaskGenerator.Infrastructure.Contracts.Context;
using Msimon.TaskGenerator.Infrastructure.Impl;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureExtension
    {
        
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITaskItemRepository, TaskItemMockedRespository>();

            var connectionString = configuration["ConnectionStrings:DatabaseConnection"];
            
            services.AddDbContext<TaskGeneratorContext>
            (
               options =>
               {
                   options.UseSqlServer(connectionString,
                               sqlServerOptions => sqlServerOptions.CommandTimeout(7200));
               },
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient
            );
            return services;
        }

    }
}