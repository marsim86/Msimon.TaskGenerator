using Msimon.TaskGenerator.Library.Contracts;
using Msimon.TaskGenerator.Library.Contracts.Service;
using Msimon.TaskGenerator.Library.Impl;
using Msimon.TaskGenerator.Library.Impl.Service;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LibraryExtension
    {
        public static IServiceCollection AddLibraryServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskGeneratorService, TaskGeneratorService>();
            services.AddSingleton<ITaskCacheService, TaskCacheService>();
           
            return services;
        }
    }
}