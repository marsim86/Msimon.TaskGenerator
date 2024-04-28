using Asp.Versioning;

#pragma warning disable CS1591 

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiVersioningExtension
    {
        public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
        {
            services
                .AddApiVersioning(opt =>
                {
                    opt.ReportApiVersions = true;
                    opt.AssumeDefaultVersionWhenUnspecified = true;
                    opt.DefaultApiVersion = new ApiVersion(1, 0);
                    opt.ApiVersionReader = new UrlSegmentApiVersionReader();
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            return services;
        }
    }
}

#pragma warning restore CS1591