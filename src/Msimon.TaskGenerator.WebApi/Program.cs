using Asp.Versioning.ApiExplorer;

#pragma warning disable CS1591

namespace Msimon.TaskGenerator.WebApi
{
    public static class Program
    {
        public const string ProductName = "ARCH";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.Sources.Clear();
            builder.Configuration
                .AddEnvironmentVariables();


            builder.Host
                .UseDefaultServiceProvider((context, options) =>
                {
                    var isDevelopment = context.HostingEnvironment.IsDevelopment();
                    options.ValidateScopes = isDevelopment;
                    options.ValidateOnBuild = isDevelopment;
                });

            builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);
            
            var app = builder.Build();
            
            startup.Configure(app, 
                builder.Environment,
                app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

            app.Run();
        }
    }
}
#pragma warning restore CS1591
