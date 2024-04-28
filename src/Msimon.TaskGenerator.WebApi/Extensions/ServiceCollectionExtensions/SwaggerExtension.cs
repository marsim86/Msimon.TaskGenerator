using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;

#pragma warning disable CS1591 

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            var provider = services
                .BuildServiceProvider()
                .GetRequiredService<IApiVersionDescriptionProvider>();

            services
                .AddSwaggerGen(c =>
                {

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        c.SwaggerDoc(description.GroupName, 
                            CreateInfoForApiVersion(description));
                    }

                    foreach (var xmlDocumentPath in GetXmlPaths())
                    {
                        c.IncludeXmlComments(xmlDocumentPath);
                    }
                });
            
            return services;
        }


        public static IApplicationBuilder UseCustomSwaggerUi(this IApplicationBuilder applicationBuilder, 
                                                             string? endpointPrefix, 
                                                             IApiVersionDescriptionProvider provider)
        {
            applicationBuilder.UseSwagger(opts =>
            {
                opts.RouteTemplate = "api-docs/{documentName}/swagger.json";
                opts.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    var protocol = httpReq.Scheme;
                    var host = httpReq.Host.Value;
                    (protocol, host) = TryReadHeaders(httpReq, protocol, host);

                    swaggerDoc.Servers = new List<OpenApiServer> { new() { Url = $"{protocol}://{host}{endpointPrefix}" } };
                });
            });

            applicationBuilder.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions.Select(x => x.GroupName))
                {
                    options.SwaggerEndpoint($"./{description}/swagger.json", description.ToUpperInvariant());
                    options.RoutePrefix = "api-docs";
                }
            });

            return applicationBuilder;
        }

        private static (string, string) TryReadHeaders(HttpRequest httpReq, string protocol, string host)
        {
            //In use when load balancer/reverse proxy does SSL offloading.
            if (httpReq.Headers.TryGetValue("X-Forwarded-Proto", out var header))
                protocol = header!;

            //In use when application is behind a reverse proxy.
            if (httpReq.Headers.TryGetValue("X-Forwarded-Host", out var reqHeader))
                host = reqHeader[0]!;

            return (protocol, host);
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Sample API",
                Version = description.ApiVersion.ToString(),
                Description = "Put your api info",
                Contact = new OpenApiContact
                {
                    Email = "support@suport.com",
                    Name = "My Company Support Team"
                },
                License = new OpenApiLicense
                {
                    Name = $"Copyright {DateTime.Now.Year}, My Company Inc. All rights reserved."
                },
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }


        private static List<string> GetXmlPaths()
        {
            return Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.AllDirectories)
                .Where(f => f.Contains("WebApi.xml") || f.Contains("Library.Contracts"))
                .ToList();
        }
    }
}

#pragma warning restore CS1591