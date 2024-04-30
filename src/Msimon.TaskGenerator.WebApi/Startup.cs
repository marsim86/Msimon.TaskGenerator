using Asp.Versioning.ApiExplorer;
using System.Text.Json.Serialization;


#pragma warning disable CS1591

namespace Msimon.TaskGenerator.WebApi
{
    public class Startup(IConfiguration configuration)
    {
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomApiVersioning();
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddCustomSwagger();
            services.AddCustomHealthChecks();
            services.AddCustomProblemDetails();

            services.AddLibraryServices()
                    .AddInfrastructureServices(configuration);

            services.AddMemoryCache();

        }

        public virtual void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider descriptionProvider)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomPathBase(configuration.GetPathBase());

            app.UseCustomSwaggerUi(configuration.GetPathBase(), descriptionProvider);

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}

#pragma warning restore CS1591