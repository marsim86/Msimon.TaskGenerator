using Hellang.Middleware.ProblemDetails;

#pragma warning disable CS1591 

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProblemDetailsExtension
    {
        public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services)
        {
            services.AddProblemDetails(opts =>
            {
                opts.IncludeExceptionDetails = (ctx, ex) =>
                {
                    var env = ctx.RequestServices.GetRequiredService<IHostEnvironment>();
                    return env.IsDevelopment();
                };

                opts.ShouldLogUnhandledException = (_, _, _) => true;
            });

            return services;
        }
    }
}

#pragma warning restore CS1591