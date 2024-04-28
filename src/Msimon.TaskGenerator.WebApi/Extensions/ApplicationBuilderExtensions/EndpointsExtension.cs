using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

#pragma warning disable CS1591 

namespace Microsoft.AspNetCore.Builder
{
    public static class EndpointsExtension
    {
        public static IApplicationBuilder UseCustomEndpoints(
            this IApplicationBuilder app,
            IConfiguration configuration)
        {
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHealthChecks(
                //    configuration.GetValue<string>("readinessHealthCheckUri") ?? 
                //    throw new NullReferenceException("readinessHealthCheckUri config value is null"),
                //    new HealthCheckOptions
                //    {
                //        ResponseWriter = WriteHealthCheckResponse
                //    });

                //endpoints.MapGet(
                //    configuration.GetValue<string>("healthHealthCheckUri") ?? 
                //    throw new InvalidOperationException("healthHealthCheckUri config value is nul"),
                //    async context => { await context.Response.WriteAsync("Ok"); });

                endpoints.MapControllers();
            });

            return app;
        }

        private static Task WriteHealthCheckResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions { Indented = true };

            using var memoryStream = new MemoryStream();
            using (var jsonWriter = new Utf8JsonWriter(memoryStream, options))
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WriteString("status", result.Status.ToString());
                jsonWriter.WriteStartObject("results");

                foreach (var healthReportEntry in result.Entries)
                {
                    jsonWriter.WriteStartObject(healthReportEntry.Key);
                    jsonWriter.WriteString("status",
                        healthReportEntry.Value.Status.ToString());
                    jsonWriter.WriteString("description",
                        healthReportEntry.Value.Description);
                    jsonWriter.WriteStartObject("data");

                    foreach (var item in healthReportEntry.Value.Data)
                    {
                        jsonWriter.WritePropertyName(item.Key);

                        JsonSerializer.Serialize(jsonWriter, item.Value,
                            item.Value?.GetType() ?? typeof(object));
                    }

                    jsonWriter.WriteEndObject();
                    jsonWriter.WriteEndObject();
                }

                jsonWriter.WriteEndObject();
                jsonWriter.WriteEndObject();
            }

            return context.Response.WriteAsync(
                Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

    }
}

#pragma warning restore CS1591